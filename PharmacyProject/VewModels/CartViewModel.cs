using System.ComponentModel.DataAnnotations;

namespace PharmacyProject.VewModels
{
    public class CartViewModel
    {
        [Required]
        public int MedicineId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime ExperationDate { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string TypeName { get; set; } = null!;

        public string? ImageURL { get; set; }
    }
}
