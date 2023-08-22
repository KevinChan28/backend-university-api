using Api_backend_university.DTO;

namespace Api_backend_university.Services
{
    public interface ITeacher
    {
        Task<int> RegisterTeacher(TeacherRegister model);
        Task<List<TeacherInformation>> GetAllTeachers();
    }
}
