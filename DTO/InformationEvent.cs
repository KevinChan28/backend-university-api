namespace Api_backend_university.DTO
{
    public class InformationEvent
    {
        public int Id { get; set; }

        public DateTime CratedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
