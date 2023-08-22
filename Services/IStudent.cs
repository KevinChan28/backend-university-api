using Api_backend_university.DTO;

namespace Api_backend_university.Services
{
    public interface IStudent
    {
        Task<int> Register(StudentRegister student);
        Task<List<StudentsWithCareer>> GetAllStudentsWithCareer();
        Task<List<StudentsWithCareer>> GetAllStudentsByCareer(int idCareer);
    }
}
