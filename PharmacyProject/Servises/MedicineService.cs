using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PharmacyProject.Data;
using PharmacyProject.Data.DataModels;
using PharmacyProject.Servises.Interfaces;
using PharmacyProject.VewModels;

namespace PharmacyProject.Servises
{
    public class MedicineService : IMedicineService
    {
        private readonly ApplicationDbContext _context;

        public MedicineService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medicine>> GetIndex()
        {
            return await _context.Medicines.ToListAsync();
        }

        public async Task<MedicineViewModel> GetAddModelAsynk()
        {
            var medicineTypes = await _context.MedicineTypes
                .Select(t => new TypeVewModel
                {
                    Id = t.Id,
                    Name = t.MedicineTypeName
                }).ToListAsync();

            var model = new MedicineViewModel
            {
                MedicineTypes = medicineTypes
            };

            return model;
        }

        public async Task AddMedicineAsync(MedicineViewModel viewModel)
        {
            var medicine = new Medicine
            {
                MedicineName = viewModel.Name,
                ExperationDate = viewModel.ExperationDate,
                Price = viewModel.Price,
                Description = viewModel.Description,
                MedicineTypeId = viewModel.Type,
                ImageURL = viewModel.ImageURL
            };

            _context.Medicines.Add(medicine);
            _context.SaveChanges();
        }

        public async Task<MedicineDetailsViewModel> GetDetails(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);

            return new MedicineDetailsViewModel
            {
                Name = medicine.MedicineName,
                ExperationDate = medicine.ExperationDate,
                Price = medicine.Price,
                Description = medicine.Description,
                ImageURL = medicine.ImageURL,
                TypeName = GetMedicineTypeName(medicine.MedicineTypeId)
            };
        }

        public async Task<AddMedicineToPharmacyViewModel> GetAddMedcineToPharmacyViewModelAsync(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);

            if(medicine == null)
            {
                return null;
            }

            var pharmacies = await _context.Pharmacies.ToListAsync();

            AddMedicineToPharmacyViewModel viewModel = new AddMedicineToPharmacyViewModel
            {
                MedicineId = medicine.Id,
                Name = medicine.MedicineName,
                Pharmacies = pharmacies.Select(p => new PharmacyCheckBox
                {
                    Id = p.Id,
                    Name = p.Name,
                    IsSelected = false
                }).ToList()
            };

            return viewModel;
        }

        private string GetMedicineTypeName(int id)
        {
            switch (id)
            {
                case 1:
                    return "Pill";
                case 2:
                    return "Syringe";
                case 3:
                    return "Syrup";
                case 4:
                    return "Powder";
                case 5:
                    return "Liquid";
                default:
                    return "Error";
            }
        }
    }
}
