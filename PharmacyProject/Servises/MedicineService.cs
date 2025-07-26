using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
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
    }
}
