namespace Api_backend_university.Repository
{
    public interface ICareerRepository
    {
        Task<int> Register(Career career);
        Task<List<Career>> GetAllCareers();
    }
}
