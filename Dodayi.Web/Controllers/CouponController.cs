using Dodayi.Web.Models;
using Dodayi.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dodayi.Web.Controllers
{
    /// <summary>
    /// Kupon işlemlerini yöneten controller sınıfı
    /// </summary>
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        /// <summary>
        /// CouponController constructor metodu
        /// </summary>
        /// <param name="couponService">Kupon servis arayüzü</param>
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        /// <summary>
        /// Kupon listesini gösteren sayfa
        /// </summary>
        /// <returns>Kupon listesi görünümü</returns>
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();

            ResponseDto? response = await _couponService.GetAllCouponAsync();

            if (response != null && response.IsSuccess && response.Result != null)
            {
                var resultString = Convert.ToString(response.Result);
                if (!string.IsNullOrEmpty(resultString))
                {
                    list = JsonConvert.DeserializeObject<List<CouponDto>>(resultString);
                }
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        /// <summary>
        /// Yeni kupon oluşturma sayfasını gösterir
        /// </summary>
        /// <returns>Kupon oluşturma formu görünümü</returns>
        public IActionResult CouponCreate()
        {
            return View();
        }

        /// <summary>
        /// Yeni kupon oluşturma işlemini gerçekleştirir
        /// </summary>
        /// <param name="model">Oluşturulacak kupon bilgisi</param>
        /// <returns>Başarılıysa kupon listesi, değilse kupon oluşturma formu</returns>
        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _couponService.CreateCouponAsync(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Coupon create successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }

            return View(model);
        }

        /// <summary>
        /// Kupon silme onay sayfasını gösterir
        /// </summary>
        /// <param name="couponId">Silinecek kuponun ID'si</param>
        /// <returns>Kupon silme onay görünümü</returns>
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? response = await _couponService.GetCouponByIdAsync(couponId);

            if (response != null && response.IsSuccess && response.Result != null)
            {
                var resultString = Convert.ToString(response.Result);
                if (!string.IsNullOrEmpty(resultString))
                {
                    CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(resultString);
                    TempData["success"] = "Coupon created successfully";
                    return View(model);
                }
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }

        /// <summary>
        /// Kupon silme işlemini gerçekleştirir
        /// </summary>
        /// <param name="model">Silinecek kupon bilgisi</param>
        /// <returns>Başarılıysa kupon listesi, değilse silme sayfası</returns>
        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto model)
        {
            ResponseDto? response = await _couponService.DeleteCouponAsync(model.CouponId);
         
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Coupon deleted successfully";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(model);
        }
    }
}
