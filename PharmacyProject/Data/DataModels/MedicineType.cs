using PharmacyProject.Common;
using System.ComponentModel.DataAnnotations;

namespace PharmacyProject.Data.DataModels
{
    public class MedicineType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MedicineTypeNameMaxLenght)]
        public string MedicineTypeName { get; set; } = null!;
    }
}
