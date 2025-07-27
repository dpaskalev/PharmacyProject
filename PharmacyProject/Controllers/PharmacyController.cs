using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyProject.Data;
using PharmacyProject.Data.DataModels;
using PharmacyProject.Servises;
using PharmacyProject.Servises.Interfaces;
using PharmacyProject.VewModels;
using System;

namespace PharmacyProject.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var modelsCollection = await _pharmacyService.GetPharmaciesAsynk();

            return View(modelsCollection);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = _pharmacyService.GetPharmacyViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PharmacyViewModel model)
        {
            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            await _pharmacyService.AddPharamcyToDatabaseAsync(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var pharmacy = await _pharmacyService.GetDetailsAsync(id);

            if(pharmacy == null)
            {
                RedirectToAction("Index");
            }

            return View(pharmacy);
        }
    }
}
