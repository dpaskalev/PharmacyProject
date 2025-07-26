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
    public class MedicineController : Controller
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await _medicineService.GetIndex();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await _medicineService.GetAddModelAsynk();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicineViewModel viewModel)
        {
            if(ModelState.IsValid == false)
            {
                var model = await _medicineService.GetAddModelAsynk();
                return View(model);
            }

            await _medicineService.AddMedicineAsync(viewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var medicine = await _medicineService.GetDetails(id);

            return View(medicine);
        }

        [HttpGet]
        public async Task<IActionResult> Assign(int medicineId)
        {
            var model = await _medicineService.GetAddMedcineToPharmacyViewModelAsync(4);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Assign(AddMedicineToPharmacyViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
