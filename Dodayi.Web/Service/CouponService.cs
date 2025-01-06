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

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                //Url = SD.CouponAPIBase + "/GetCoupon/" + couponCode,
                //Url = SD.CouponAPIBase + "/api/coupons/" + couponCode,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode,
            });
        }
        public async Task<ResponseDto?> GetAllCouponAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                //Url = SD.CouponAPIBase + "/GetAllCoupons",
                //Url = SD.CouponAPIBase + "/api/coupons",
                Url = SD.CouponAPIBase + "/api/coupon",
            });
        }
        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                //Url = SD.CouponAPIBase + "/api/coupon/GetById/" + id,
                Url = SD.CouponAPIBase + "/api/coupon/" + id,
            });
        }
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Url = SD.CouponAPIBase + "/api/coupon",
                Data = couponDto
            });
        }
        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.CouponAPIBase + "/api/coupon",
                Data = couponDto
            });
        }
        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                //Url = SD.CouponAPIBase + "/api/coupon/Delete/" + id,
                Url = SD.CouponAPIBase + "/api/coupon/" + id,
            });
        }
    }
}
