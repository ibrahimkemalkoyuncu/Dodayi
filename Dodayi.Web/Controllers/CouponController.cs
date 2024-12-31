﻿using Dodayi.Web.Models;
using Dodayi.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dodayi.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();

            Response? response = await _couponService.GetAllCouponAsync();

            if(response != null & response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> CouponCreate()
        {      

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if(ModelState.IsValid)
            {
                Response? response = await _couponService.CreateCouponAsync(model);
                if (response != null && response.IsSuccess)
                {
                    //return RedirectToAction("CouponIndex");
                    return RedirectToAction(nameof(CouponIndex));
                }
            }

            return View(model);
        }
    }
}
