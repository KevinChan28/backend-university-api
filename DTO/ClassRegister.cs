namespace Api_backend_university.DTO
{
    public class ClassRegister
    {
        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public string Days { get; set; } = null!;

        public int CourseId { get; set; }

        public int? TeacherId { get; set; }
    }
}
