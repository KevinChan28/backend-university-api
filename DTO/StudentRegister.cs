using System.ComponentModel.DataAnnotations;

namespace Api_backend_university.DTO
{
    public class StudentRegister
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string? Gender { get; set; }

        public string? Telephone { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? CareerId { get; set; }

        public UserRegister User { get; set; }


    }
}
