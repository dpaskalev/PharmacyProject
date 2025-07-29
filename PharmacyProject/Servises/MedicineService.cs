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

        public async Task<IEnumerable<MedicineIndexViewModel>> GetIndex(string userId)
        {
            var Medicines = await _context.Medicines
                .Where(m => m.IsDeleted == false)
                .Select(m => new MedicineIndexViewModel
                {
                    Id = m.Id,
                    Name = m.MedicineName,
                    ExpeationDate = m.ExperationDate,
                    Price = m.Price,
                    Description = m.Description,
                    TypeName = m.MedicineType.MedicineTypeName,
                    ImageURL = m.ImageURL,
                    IsPublisher = m.UserId == userId,
                    HasBought = userId != null && _context.UsersMedicines.Any(um => um.MedicineId == m.Id && um.UserId == userId)
                })
                .ToListAsync();

            return Medicines;
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

        public async Task AddMedicineAsync(MedicineViewModel viewModel, string userId)
        {
            var medicine = new Medicine
            {
                MedicineName = viewModel.Name,
                ExperationDate = viewModel.ExperationDate,
                Price = viewModel.Price,
                Description = viewModel.Description,
                MedicineTypeId = viewModel.Type,
                ImageURL = viewModel.ImageURL,
                UserId = userId
            };

            await _context.Medicines.AddAsync(medicine);
            await _context.SaveChangesAsync();
        }

        public async Task<MedicineDetailsViewModel> GetDetails(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);

            if(medicine == null)
            {
                return null;
            }

            return new MedicineDetailsViewModel
            {
                Name = medicine.MedicineName,
                ExperationDate = medicine.ExperationDate,
                Price = medicine.Price,
                Description = medicine.Description,
                ImageURL = medicine.ImageURL,
                //TypeName = medicine.MedicineType.MedicineTypeName
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

        public async Task AssignMedicineAsync(AddMedicineToPharmacyViewModel model)
        {
            var AleadyAssignedPharmacies = await _context.PharmaciesMedicines
                .Where(pm => pm.MedicineId == model.MedicineId)
                .ToListAsync();

            _context.RemoveRange(AleadyAssignedPharmacies);

            foreach(var pharmacy in model.Pharmacies)
            {
                if (pharmacy.IsSelected)
                {
                    var pharmacyMedicine = new PharmacyMedicine
                    {
                        PharmacyId = pharmacy.Id,
                        MedicineId = model.MedicineId
                    };

                    await _context.PharmaciesMedicines.AddAsync(pharmacyMedicine);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<MedicineDeleteViewModel> GetMedicineDeleteViewModel(int id)
        {
            var model = await _context.Medicines
                .Where(m => m.Id == id)
                .Select(m => new MedicineDeleteViewModel
                {
                    Id = m.Id,
                    Name = m.MedicineName,
                    PublisherId = m.UserId,
                    PublisherName = m.User.UserName
                }).FirstOrDefaultAsync();

            return model;
        }

        public async Task Delete(int id)
        {
            var medicine = await _context.Medicines
                .FirstOrDefaultAsync(m => m.Id == id);

            if(medicine != null)
            {
                medicine.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<MedicineSearchViewModel> GetSearchViewModel()
        {
            var model = new MedicineSearchViewModel();

            return model;
        }

        public async Task<IEnumerable<MedicineIndexViewModel>> GetSearchResultAsync(MedicineSearchViewModel model, string userId)
        {
            var modelCollection = await _context.Medicines
                .Where(m => m.IsDeleted == false)
                .Where(m => m.MedicineName == model.Name)
                .Select(m => new MedicineIndexViewModel
                {
                    Id = m.Id,
                    Name = m.MedicineName,
                    ExpeationDate = m.ExperationDate,
                    Price = m.Price,
                    Description = m.Description,
                    TypeName = m.MedicineType.MedicineTypeName,
                    ImageURL = m.ImageURL,
                    IsPublisher = m.UserId == userId,
                    HasBought = userId != null && _context.UsersMedicines.Any(um => um.MedicineId == m.Id && um.UserId == userId)
                })
                .ToListAsync();

            return modelCollection;
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
