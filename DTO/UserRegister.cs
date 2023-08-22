using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Api_backend_university.DTO
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required, PasswordPropertyText]
        public string Password { get; set; }

        public int RolId { get; set; }
    }
}
