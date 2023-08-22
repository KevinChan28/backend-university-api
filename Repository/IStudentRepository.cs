namespace Api_backend_university.Repository
{
    public interface IStudentRepository
    {
        Task<int> Register(Student student);
        Task<Student> GetStudentById(int idStudent);
        Task<List<Student>> GetAllStudentsWithCareer();
    }
}
