using System.ComponentModel.DataAnnotations;

namespace Api_backend_university.DTO
{
    public class CareerInformation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

    }
}
