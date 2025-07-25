using Microsoft.AspNetCore.Mvc;
using PharmacyProject.Data;
using PharmacyProject.VewModels;
using System;

namespace PharmacyProject.Controllers
{
    public class MedicineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicineController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var medicines = _context.Medicines.ToList();
            return View(medicines);
        }

        [HttpGet]
        public IActionResult Create()
        {
            throw new NotImplementedException();
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
