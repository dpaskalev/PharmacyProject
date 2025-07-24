using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.Data.DataModels;
using System.Globalization;
using System.Reflection.Emit;

namespace PharmacyProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<MedicineType> MedicineTypes { get; set; }

        public DbSet<Pharmacy> Pharmacies { get; set; }

        public DbSet<PharmacyMedicine> PharmaciesMedicines { get; set; }

        public DbSet<UserMedicine> UsersMedicines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var defaultUser = new IdentityUser
            {
                Id = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                    new IdentityUser { UserName = "admin@gmail.com" },
                    "123456!")
            };
            builder.Entity<IdentityUser>().HasData(defaultUser);

            builder.Entity<MedicineType>().HasData(
                new MedicineType { Id = 1, MedicineTypeName = "Pill" },
                new MedicineType { Id = 2, MedicineTypeName = "Syringe" },
                new MedicineType { Id = 3, MedicineTypeName = "Syrup" },
                new MedicineType { Id = 4, MedicineTypeName = "Powder" },
                new MedicineType { Id = 5, MedicineTypeName = "Liquid" }
                );

            builder.Entity<Medicine>().HasData(
                new Medicine
                {
                    Id = 1,
                    MedicineName = "Med_1",
                    ExperationDate = DateTime.Today,
                    Price = 100,
                    Description = "Caution",
                    MedicineTypeId = 1,
                    IsDeleted = false
                },

                new Medicine
                {
                    Id = 2,
                    MedicineName = "Med_2",
                    ExperationDate = DateTime.Today,
                    Price = 200,
                    Description = "Caution",
                    MedicineTypeId = 2,
                    IsDeleted = false
                },

                new Medicine
                {
                    Id = 3,
                    MedicineName = "Med_3",
                    ExperationDate = DateTime.Today,
                    Price = 100,
                    Description = "Caution",
                    MedicineTypeId = 3,
                    IsDeleted = false
                }
            );

            builder.Entity<Pharmacy>().HasData(
                new Pharmacy
                {
                    Id = 1,
                    Name = "Pharmacy_1",
                    Loctaion = "Suhata_Reka"
                },

                new Pharmacy
                {
                    Id = 2,
                    Name = "Pharmacy_2",
                    Loctaion = "Suhata_Reka"
                },

                new Pharmacy
                {
                    Id = 3,
                    Name = "Pharmacy_3",
                    Loctaion = "Suhata_Reka"
                }
            );
        }
    }
}
