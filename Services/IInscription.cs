using Api_backend_university.DTO;

namespace Api_backend_university.Services
{
    public interface IInscription
    {
        Task<int> AddStudentToCourse(InscriptionRegister inscriptionRegister);
        Task<List<ClassInformation>> GetAllCoursesToStudent(int studentId);
    }
}
