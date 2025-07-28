using System.ComponentModel.DataAnnotations;

namespace PharmacyProject.VewModels
{
    public class MedicineDeleteViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string PublisherId { get; set; } = null!;

        [Required]
        public string PublisherName { get; set; } = null!;
    }
}
