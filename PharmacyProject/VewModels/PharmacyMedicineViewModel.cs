using System.ComponentModel.DataAnnotations;

namespace PharmacyProject.VewModels
{
    public class PharmacyMedicineViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PharmacyId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public bool IsPublisher { get; set; }
    }
}
