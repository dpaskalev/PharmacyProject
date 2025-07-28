using Microsoft.AspNetCore.Identity;
using PharmacyProject.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyProject.Data.DataModels
{
    public class Pharmacy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PharmacyNameMaxLebnght)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.PharmacyLocationMaxLenght)]
        public string Loctaion { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public ICollection<PharmacyMedicine> PharmaciesMedicines { get; set; } = new List<PharmacyMedicine>();
    }
}
