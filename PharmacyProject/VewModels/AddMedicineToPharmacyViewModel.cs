using System.ComponentModel.DataAnnotations;

namespace PharmacyProject.VewModels
{
    public class AddMedicineToPharmacyViewModel
    {
        [Required]
        public int MedicineId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public List<PharmacyCheckBox> Pharmacies { get; set; } = new List<PharmacyCheckBox>();
    }
}
