using Dodayi.Services.CouponAPI.Data;
using Dodayi.Services.CouponAPI.Dto;
using Dodayi.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dodayi.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private Response response;  
        public CouponAPIController(AppDbContext db)
        {
            _db = db;
            response = new Response();  
        }


        [HttpGet]
        public Response Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                response.Result = objList;  
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
                Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                CouponDto couponDto = new CouponDto()
                {
                    CouponId = obj.CouponId,
                    CouponCode = obj.CouponCode,
                    DiscountAmount = obj.DiscountAmount,
                    MinAmount = obj.MinAmount
                };

                response.Result = couponDto;  
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
