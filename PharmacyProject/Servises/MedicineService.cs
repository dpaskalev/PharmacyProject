using Microsoft.AspNetCore.Mvc;
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


    }
}
