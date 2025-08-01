﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyProject.Data;
using PharmacyProject.Data.DataModels;
using PharmacyProject.Servises;
using PharmacyProject.Servises.Interfaces;
using PharmacyProject.VewModels;
using System;

namespace PharmacyProject.Controllers
{
    public class PharmacyController : BaseController
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var modelsCollection = await _pharmacyService.GetPharmaciesAsynk(GetUserId());

            if (modelsCollection == null)
            {
                return View("CustomErrorView");
            }

            return View(modelsCollection);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = _pharmacyService.GetPharmacyViewModel();

            if (model == null)
            {
                return View("CustomErrorView");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PharmacyViewModel model)
        {
            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            await _pharmacyService.AddPharamcyToDatabaseAsync(model, GetUserId());

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var pharmacy = await _pharmacyService.GetDetailsAsync(id, GetUserId());

            if (pharmacy == null)
            {
                return View("CustomErrorView");
            }

            return View(pharmacy);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromDetails(PharmacyMedicineViewModel model)
        {
            await _pharmacyService.RemoveFromDetailsAsync(model.Id, model.PharmacyId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _pharmacyService.GetPharmacyDeleteViewModel(id);

            if (model == null)
            {
                return View("CustomErrorView");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MedicineDeleteViewModel model)
        {
            await _pharmacyService.Delete(model.Id);

            return RedirectToAction("Index");
        }



    }
}
