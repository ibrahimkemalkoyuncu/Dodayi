using Dodayi.Services.ShoppingCartAPI.Dto;

namespace Dodayi.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
