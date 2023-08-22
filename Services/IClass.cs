using Api_backend_university.DTO;

namespace Api_backend_university.Services
{
    public interface IClass
    {
        Task<int> RegisterClass(ClassRegister classRegister);
        Task<List<ClassInformation>> GetAllClasses();
    }
}
