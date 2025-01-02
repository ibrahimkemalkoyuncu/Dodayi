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

            if (response != null & response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response.Message;
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
            if (ModelState.IsValid)
            {
                Response? response = await _couponService.CreateCouponAsync(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Coupon create successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response.Message;
                }
            }

            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            Response? response = await _couponService.GetCouponByIdAsync(couponId);

            if (response != null && response.IsSuccess)
            {
                CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                TempData["success"] = "Coupon created successfully";
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }


        [HttpDelete]
        public async Task<IActionResult> CouponDelete(CouponDto model)
        {

                Response? response = await _couponService.DeleteCouponAsync(model.CouponId);
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