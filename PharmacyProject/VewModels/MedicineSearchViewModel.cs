using System.ComponentModel.DataAnnotations;

namespace PharmacyProject.VewModels
{
    public class MedicineSearchViewModel
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
