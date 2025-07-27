using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
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
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<CartViewModel>> GetIndexAsync(string userId)
        {
            var model = await _context.UsersMedicines
                .Where(um => um.UserId == userId)
                .Include(um => um.Medicine)
                .Select(um => new CartViewModel
                {
                    MedicineId = um.MedicineId,
                    Name = um.Medicine.MedicineName,
                    ExperationDate = um.Medicine.ExperationDate,
                    Description = um.Medicine.Description,
                    //TypeName = um.Medicine.MedicineType.MedicineTypeName
                    TypeName = GetMedicineTypeName(um.Medicine.MedicineTypeId),
                    ImageURL = um.Medicine.ImageURL
                }).ToListAsync();

            return model;
        }

        public async Task AddAsync(int medicineId, string userId)
        {
            var userMedicine = await _context.UsersMedicines
                .FirstOrDefaultAsync(um => um.UserId == userId && um.MedicineId == medicineId);

            if(userMedicine == null)
            {
                userMedicine = new UserMedicine
                {
                    UserId = userId,
                    MedicineId = medicineId
                };

                await _context.UsersMedicines.AddAsync(userMedicine);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int medicineId, string userId)
        {
            var userMedicine = await _context.UsersMedicines
                .FirstOrDefaultAsync(um => um.UserId == userId && um.MedicineId == medicineId);

            if(userMedicine != null)
            {
                userMedicine.Medicine.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
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
