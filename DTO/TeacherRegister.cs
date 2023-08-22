using System.ComponentModel.DataAnnotations;

namespace Api_backend_university.DTO
{
    public class TeacherRegister
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? Telephone { get; set; }

        public UserRegister User { get; set; }
    }
}
