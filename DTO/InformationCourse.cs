namespace Api_backend_university.DTO
{
    public class InformationCourse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int Semester { get; set; }

        public int? EventId { get; set; }

        public virtual InformationEvent? Event { get; set; }
    }
}
