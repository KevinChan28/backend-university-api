namespace Api_backend_university.Repository
{
    public interface IClassRepository
    {
        Task<int> RegisterClass(Class classNew);
        Task<List<Class>> GetAllClasses();
    }
}
