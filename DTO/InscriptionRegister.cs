using System.ComponentModel.DataAnnotations;

namespace Api_backend_university.DTO
{
    public class InscriptionRegister
    {

        public bool? IsInscribed { get; set; }
        [Required]
        public int ClassId { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}
