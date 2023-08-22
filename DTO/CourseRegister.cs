namespace Api_backend_university.DTO
{
    public class CourseRegister
    {

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int Semester { get; set; }

        public virtual EventRegister? Event { get; set; }
    }
}
