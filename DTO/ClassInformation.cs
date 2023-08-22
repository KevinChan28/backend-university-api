namespace Api_backend_university.DTO
{
    public class ClassInformation
    {
        public int Id { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public string Days { get; set; } = null!;

        public virtual InfoCourseOfStudent Course { get; set; }

        public virtual TeacherInformation Teacher { get; set; }
    }
}
