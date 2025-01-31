using AutoMapper;
using Dodayi.Services.ProductAPI.Data;
using Dodayi.Services.ProductAPI.Dto;
using Dodayi.Services.ProductAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dodayi.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    //[Authorize]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext db;
        private Response response;
        private IMapper mapper;
        public ProductAPIController(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            response = new Response();
            mapper = _mapper;
        }


        [HttpGet]
        public Response Get()
        {
            try
            {
                IEnumerable<Product> objList = db.Products.ToList();
                response.Result = mapper.Map<IEnumerable<ProductDto>>(objList);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }


        [HttpGet]
        [Route("{id:int}")]
        public Response Get(int id)
        {
            try
            {
                Product obj = db.Products.First(u => u.ProductId == id);      
                response.Result = mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public Response Post([FromBody] ProductDto dto)
        {
            try
            {
                Product obj = mapper.Map<Product>(dto);
                db.Products.Add(obj);
                db.SaveChanges();

                response.Result = mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPut]
        //[Authorize(Roles = "ADMIN")]
        public Response Put([FromBody] ProductDto dto)
        {
            try
            {
                Product obj = mapper.Map<Product>(dto);
                db.Products.Update(obj);
                db.SaveChanges();

                response.Result = mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        //[Authorize(Roles = "ADMIN")]
        public Response Delete(int id)
        {
            try
            {
                Product obj = db.Products.First(u => u.ProductId == id);
                db.Products.Remove(obj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
