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
    public class PharmacyService : IPharmacyService
    {
        private readonly ApplicationDbContext _context;

        public PharmacyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PharmacyViewModel>> GetPharmaciesAsynk(string userId)
        {
            var modelsCollection = await _context.Pharmacies
                .Where(p => p.IsDeleted == false)
                .ToListAsync();

            var pharmacyViewModels = modelsCollection.Select(p => new PharmacyViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Location = p.Loctaion,
                IsPublisher = p.UserId == userId
            });

            return pharmacyViewModels;
        }

        public PharmacyViewModel GetPharmacyViewModel()
        {
            var model = new PharmacyViewModel();

            return model;
        }

        public async Task AddPharamcyToDatabaseAsync(PharmacyViewModel model, string userId)
        {
            var pharmacy = new Pharmacy
            {
                Name = model.Name,
                Loctaion = model.Location,
                UserId = userId
            };

            await _context.Pharmacies.AddAsync(pharmacy);
            await _context.SaveChangesAsync();
        }

        public async Task<PharmacyDetailsViewModel> GetDetailsAsync(int id)
        {
            var pharmacy = await _context.Pharmacies
                .Include(p => p.PharmaciesMedicines)
                .ThenInclude(pm => pm.Medicine)
                .Where(m => m.IsDeleted == false)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(pharmacy == null)
            {
                return null;
            }

            var pharmacyDetailsViewModel = new PharmacyDetailsViewModel
            {
                Id = pharmacy.Id,
                Name = pharmacy.Name,
                Location = pharmacy.Loctaion,
                Medicines = pharmacy.PharmaciesMedicines.Select(pm => new PharmacyMedicineViewModel
                {
                    Id = pm.Medicine.Id,
                    Name = pm.Medicine.MedicineName
                }).ToList()
            };

            return pharmacyDetailsViewModel;
        }

        public async Task<PharmacyDeleteViewModel> GetPharmacyDeleteViewModel(int id)
        {
            var model = await _context.Pharmacies
                .Where(m => m.Id == id)
                .Select(m => new PharmacyDeleteViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    PublisherId = m.UserId,
                    PublisherName = m.User.UserName
                }).FirstOrDefaultAsync();

            return model;
        }

        public async Task Delete(int id)
        {
            var medicine = await _context.Pharmacies
                .FirstOrDefaultAsync(m => m.Id == id);

            if (medicine != null)
            {
                medicine.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
