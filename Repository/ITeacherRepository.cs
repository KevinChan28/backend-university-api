namespace Api_backend_university.Repository
{
    public interface ITeacherRepository
    {
        Task<int> Register(Teacher teacher);
        Task<List<Teacher>> GetAllTeachers();
    }
}
