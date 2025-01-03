using Dodayi.Web.Models;
using Dodayi.Web.Service.IService;
using Dodayi.Web.Utility;

namespace Dodayi.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<Response?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.GET,
                //Url = SD.CouponAPIBase + "/GetCoupon/" + couponCode,
                //Url = SD.CouponAPIBase + "/api/coupons/" + couponCode,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode,
            });
        }
        public async Task<Response?> GetAllCouponAsync()
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.GET,
                //Url = SD.CouponAPIBase + "/GetAllCoupons",
                //Url = SD.CouponAPIBase + "/api/coupons",
                Url = SD.CouponAPIBase + "/api/coupon",
            });
        }
        public async Task<Response?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.GET,
                //Url = SD.CouponAPIBase + "/api/coupon/GetById/" + id,
                Url = SD.CouponAPIBase + "/api/coupon/" + id,
            });
        }
        public async Task<Response?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.POST,
                Url = SD.CouponAPIBase + "/api/coupon",
                Data = couponDto
            });
        }
        public async Task<Response?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.CouponAPIBase + "/api/coupon",
                Data = couponDto
            });
        }
        public async Task<Response?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.DELETE,
                //Url = SD.CouponAPIBase + "/api/coupon/Delete/" + id,
                Url = SD.CouponAPIBase + "/api/coupon/" + id,
            });
        }
    }
}
