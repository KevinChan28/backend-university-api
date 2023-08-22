namespace Api_backend_university.Repository
{
    public interface ICourseRepository
    {
        Task<int> RegisterCourse(Course course);
        Task<List<Course>> GetAllCourses();
    }
}
