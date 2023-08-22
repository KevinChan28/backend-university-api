using Api_backend_university.DTO;

namespace Api_backend_university.Services
{
    public interface ICareer
    {
        Task<int> Register(CareerRegister model);
        Task<List<Career>> GetAllCareers();
    }
}
