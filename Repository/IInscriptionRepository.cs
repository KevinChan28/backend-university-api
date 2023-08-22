

namespace Api_backend_university.Repository
{
    public interface IInscriptionRepository
    {
        Task<int> AddStudentToClass(Inscription inscription);
        Task<List<Inscription>> GetAllClassesToStudent(int studentId);
    }
}
