using System.ComponentModel.DataAnnotations;

namespace PharmacyProject.VewModels
{
    public class PharmacyCheckBox
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public bool IsSelected { get; set; }
    }
}
