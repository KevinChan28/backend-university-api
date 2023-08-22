namespace Api_backend_university.Services
{
    public interface IRoles
    {
        Task<List<Role>> GetAllRoles();
    }
}
