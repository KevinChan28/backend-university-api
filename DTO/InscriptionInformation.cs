namespace Api_backend_university.DTO
{
    public class InscriptionInformation
    {
        public int IdInscription { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool? IsInscribed { get; set; }

        public int? ClassId { get; set; }
        public InfoCourseOfStudent Class {  get; set; }
    }
}
