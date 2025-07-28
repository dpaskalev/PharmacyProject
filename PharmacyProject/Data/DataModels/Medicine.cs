using PharmacyProject.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PharmacyProject.Data.DataModels
{
    public class Medicine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MedicineNameMaxLenght)]
        public string MedicineName { get; set; } = null!;

        [Required]
        public DateTime ExperationDate { get; set; }

        [Required]
        [Range(ValidationConstants.MedicinePriceMinValue, ValidationConstants.MedicinePriceMaxValue)]
        public double Price { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MedicineDescriptionMaxValue)]
        public string Description { get; set; } = null!;

        [Required]
        public int MedicineTypeId { get; set; }

        [ForeignKey(nameof(MedicineTypeId))]
        public MedicineType MedicineType { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public string? ImageURL { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<PharmacyMedicine> PharmaciesMedicines { get; set; } = new List<PharmacyMedicine>();

        public ICollection<UserMedicine> UsersMedicines { get; set; } = new List<UserMedicine>();
    }
}
