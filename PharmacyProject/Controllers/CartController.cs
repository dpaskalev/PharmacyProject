using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmacyProject.Data;
using PharmacyProject.Data.DataModels;
using PharmacyProject.Servises;
using PharmacyProject.Servises.Interfaces;
using PharmacyProject.VewModels;
using System;

namespace PharmacyProject.Controllers
{
    [Authorize]
    public class CartController : BaseController
    {
        private readonly ICartService _cartService;

        public CartController(UserManager<IdentityUser> userManager, ICartService cartService)
            :base(userManager)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _cartService.GetIndexAsync(GetUserId());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int medicineId)
        {
            await _cartService.AddAsync(medicineId, GetUserId());

            return RedirectToAction("Index", "Medicine");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int medicineId)
        {
            await _cartService.RemoveAsync(medicineId, GetUserId());

            return RedirectToAction("Index", "Medicine");
        }
    }
}
