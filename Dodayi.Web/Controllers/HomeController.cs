using Dodayi.Web.Models;
using Dodayi.Web.Service.IService;
using Dodayi.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;

namespace Dodayi.Web.Controllers
{
    /// <summary>
    /// Ana sayfa ve temel sayfa işlemlerini yöneten controller sınıfı
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        /// <summary>
        /// HomeController constructor metodu
        /// </summary>
        /// <param name="productService">Ürün servis arayüzü</param>
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Ana sayfa görünümünü döndürür ve ürün listesini getirir
        /// </summary>
        /// <returns>Ana sayfa görünümü</returns>
        public async Task<IActionResult> Index()
        {
            List<ProductDto>? list = new();

            ResponseDto? response = await _productService.GetAllProductAsync();

            if (response != null && response.IsSuccess && response.Result != null)
            {
                var resultString = Convert.ToString(response.Result);
                if (!string.IsNullOrEmpty(resultString))
                {
                    list = JsonConvert.DeserializeObject<List<ProductDto>>(resultString);
                }
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        /// <summary>
        /// Ürün detay sayfasını gösterir. Kimlik doğrulama gerektirir.
        /// </summary>
        /// <param name="productId">Detayları gösterilecek ürünün ID'si</param>
        /// <returns>Ürün detay görünümü</returns>
        [Authorize]
        public async Task<IActionResult> ProductDetails(int productId)
        {
            ProductDto? model = new();

            ResponseDto? response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess && response.Result != null)
            {
                var resultString = Convert.ToString(response.Result);
                if (!string.IsNullOrEmpty(resultString))
                {
                    model = JsonConvert.DeserializeObject<ProductDto>(resultString);
                }
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(model);
        }

        /// <summary>
        /// Gizlilik sayfasını gösterir. Sadece Admin rolüne sahip kullanıcılar erişebilir.
        /// </summary>
        /// <returns>Gizlilik sayfası görünümü</returns>
        [Authorize(Roles =SD.RoleAdmin)]
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Hata sayfasını gösterir
        /// </summary>
        /// <returns>Hata sayfası görünümü</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
