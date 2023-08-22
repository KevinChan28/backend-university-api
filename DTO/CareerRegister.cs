using System.ComponentModel.DataAnnotations;

namespace Api_backend_university.DTO
{
    public class CareerRegister
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
