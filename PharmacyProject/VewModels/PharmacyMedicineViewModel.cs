using System.ComponentModel.DataAnnotations;

namespace PharmacyProject.VewModels
{
    public class PharmacyMedicineViewModel
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
