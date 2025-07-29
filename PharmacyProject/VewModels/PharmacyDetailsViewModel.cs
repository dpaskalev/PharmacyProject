using System.ComponentModel.DataAnnotations;

namespace PharmacyProject.VewModels
{
    public class PharmacyDetailsViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Location { get; set; } = null!;

        public List<PharmacyMedicineViewModel> Medicines { get; set; } = new List<PharmacyMedicineViewModel>();
    }
}
