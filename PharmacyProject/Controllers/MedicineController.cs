using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyProject.Data;
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
        public IActionResult Create(MedicineViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Assign(int medicineId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Assign(AddMedicineToPharmacyViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
