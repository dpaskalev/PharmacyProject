using PharmacyProject.Common;
using System.ComponentModel.DataAnnotations;

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

        public ICollection<PharmacyMedicine> PharmaciesMedicines { get; set; } = new List<PharmacyMedicine>();
    }
}
