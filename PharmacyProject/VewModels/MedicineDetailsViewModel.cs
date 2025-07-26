using PharmacyProject.Common;
using System.ComponentModel.DataAnnotations;

namespace PharmacyProject.VewModels
{
    public class MedicineDetailsViewModel
    {
        public string Name { get; set; } = null!;

        public DateTime ExperationDate { get; set; }

        public double Price { get; set; }

        public string Description { get; set; } = null!;

        public string? ImageURL { get; set; }

        public string TypeName { get; set; } = null!;
    }
}
