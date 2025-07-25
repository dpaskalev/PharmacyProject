using PharmacyProject.Data.DataModels;
using System.ComponentModel.DataAnnotations;
using PharmacyProject.Common;

namespace PharmacyProject.VewModels
{
    public class MedicineViewModel
    {

        [Required(ErrorMessage = "Name is required")]
        [StringLength(ValidationConstants.MedicineNameMaxLenght, ErrorMessage = "Incorect name lenght")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Experation date is required")]
        public DateTime ExperationDate { get; set; }

        [Required(ErrorMessage = "Proce is required")]
        [Range(ValidationConstants.MedicinePriceMinValue, ValidationConstants.MedicinePriceMaxValue)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;

        public string? ImageURL { get; set; }

        [Range(ValidationConstants.MedicineTypeMinCount, ValidationConstants.MedicineTypeMaxCount)]
        public int Type { get; set; }

        public IEnumerable<MedicineType>? MedicineTypes { get; set; }
    }
}
