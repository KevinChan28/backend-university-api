namespace Api_backend_university.DTO
{
    public class InfoCourseOfStudent
    {
        public int IdCourse { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int Semester { get; set; }
    }
}
