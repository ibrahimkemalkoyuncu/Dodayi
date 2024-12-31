using Dodayi.Web.Models;
using Dodayi.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dodayi.Web.Controllers
{
    public class ArbisKeywordController : Controller
    {
        private readonly IArbisKeywordService _arbisKeywordService;

        public ArbisKeywordController(IArbisKeywordService arbisKeywordService)
        {
            _arbisKeywordService = arbisKeywordService;
        }

        public async Task<IActionResult> ArbisKeywordFilterByParentIdGoToIndex(int parentId = 1)
        {
            List<ArbisKeywordDto>? list = new();

            Response? response = await _arbisKeywordService.GetListByParentIdAsync(parentId);

            if (response != null & response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ArbisKeywordDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> ArbisKeywordFilterByIdGoToIndex(int id = 121811)
        {
            ArbisKeywordDto? item = new();

            Response? response = await _arbisKeywordService.GetByIdAsync(id);

            if (response != null & response.IsSuccess)
            {
                item = JsonConvert.DeserializeObject<ArbisKeywordDto>(Convert.ToString(response.Result));
            }

            return View(item);
        }
    }
}
