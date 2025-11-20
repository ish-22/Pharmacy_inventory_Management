using System.ComponentModel.DataAnnotations;

namespace SPC.Models.Entities
{
    public class PharmacyDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
