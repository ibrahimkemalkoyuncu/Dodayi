using Dodayi.Web.Models;

namespace Dodayi.Web.Service.IService
{
    public interface ICouponService
    {
        Task<Response?> GetCouponAsync(string couponCode);
        Task<Response?> GetAllCouponAsync();
        Task<Response?> GetCouponByIdAsync(int id);
        Task<Response?> CreateCouponAsync(CouponDto couponDto);
        Task<Response?> UpdateCouponAsync(CouponDto couponDto);
        Task<Response?> DeleteCouponAsync(int id);  
    }
}
