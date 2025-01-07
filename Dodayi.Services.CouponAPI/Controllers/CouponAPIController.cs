using AutoMapper;
using Dodayi.Services.CouponAPI.Data;
using Dodayi.Services.CouponAPI.Dto;
using Dodayi.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dodayi.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    [Authorize]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext db;
        private Response response;
        private IMapper mapper;
        public CouponAPIController(AppDbContext _db, IMapper _mapper)
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
                IEnumerable<Coupon> objList = db.Coupons.ToList();
                response.Result = mapper.Map<IEnumerable<CouponDto>>(objList);
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
                Coupon obj = db.Coupons.First(u => u.CouponId == id);      
                response.Result = mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public Response GetByCode(string code)
        {
            try
            {
                Coupon obj = db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
                response.Result = mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPost]
        public Response Post([FromBody] CouponDto dto)
        {
            try
            {
                Coupon obj = mapper.Map<Coupon>(dto);
                db.Coupons.Add(obj);
                db.SaveChanges();

                response.Result = mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPut]
        public Response Put([FromBody] CouponDto dto)
        {
            try
            {
                Coupon obj = mapper.Map<Coupon>(dto);
                db.Coupons.Update(obj);
                db.SaveChanges();

                response.Result = mapper.Map<CouponDto>(obj);
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
        public Response Delete(int id)
        {
            try
            {
                Coupon obj = db.Coupons.First(u => u.CouponId == id);
                db.Coupons.Remove(obj);
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
