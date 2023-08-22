using Api_backend_university.DTO;

namespace Api_backend_university.Services
{
    public interface ICourse
    {
        Task<int> RegisterCourse(CourseRegister courseRegister);
        Task<List<InformationCourse>> GetAllCourses();
    }
}
