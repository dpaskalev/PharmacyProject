using System.ComponentModel.DataAnnotations;

namespace PharmacyProject.VewModels
{
    public class MedicineIndexViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime ExpeationDate { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string TypeName { get; set; } = null!;

        public string? ImageURL { get; set; }

        [Required]
        public bool IsPublisher { get; set; }

        [Required]
        public bool HasBought { get; set; }
    }
}
