namespace Api_backend_university.Repository
{
    public interface IRolesRepository
    {
        Task<List<Role>> GetAllRoles();
    }
}
