﻿using Dodayi.Web.Models;
using Dodayi.Web.Service;
using Dodayi.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dodayi.Web.Controllers
{
    public class DetailController : Controller
    {
        private readonly IDetailService _detailService;
        private const int PageSize = 1000; // Her sayfada gösterilecek öğe sayısı

        public DetailController(IDetailService detailService)
        {
            _detailService = detailService;   
        }

        //public async Task<IActionResult> DetailIndex()
        //{
        //    List<DetailDto>? list = new();

        //    Response? response = await _detailService.GetAllDetaiAsync();

        //    if (response != null & response.IsSuccess)
        //    {
        //        list = JsonConvert.DeserializeObject<List<DetailDto>>(Convert.ToString(response.Result));
        //    }

        //    return View(list);
        //}

        public async Task<IActionResult> DetailIndex(int? page)
        {
            int pageNumber = page ?? 1;
            List<DetailDto>? allItems = new();

            Response? response = await _detailService.GetAllDetaiAsync();
            if (response != null && response.IsSuccess)
            {
                allItems = JsonConvert.DeserializeObject<List<DetailDto>>(Convert.ToString(response.Result));
            }

            // Pagination işlemi
            var items = allItems
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var pagedList = new PagedList<DetailDto>(
                items,
                allItems.Count,
                pageNumber,
                PageSize
            );

            return View(pagedList);
        }

        public async Task<IActionResult> AddMakineTechizatDetail()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMakineTechizatDetail(DetailDto model)
        {
            if (ModelState.IsValid)
            {
                Response? response = await _detailService.AddMakineTechizatDetailAsync(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(DetailIndex));
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ProjeyeIdveTureGoreDetailGetir(long projectId, int? PiyasaTuru)
        {
            projectId = 356;
            PiyasaTuru = 1;

            List<DetailDto>? list = new();

            Response? response = await _detailService.ProjeyeIdveTureGoreDetailGetirAsync(projectId, PiyasaTuru);

            if (response != null & response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DetailDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
    }
}