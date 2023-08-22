using Api_backend_university.Repository;

namespace Api_backend_university.Services.Imp
{
    public class ImpRoles : IRoles
    {
        readonly IRolesRepository _rolesRepository;

        public ImpRoles(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }


        public async Task<List<Role>> GetAllRoles()
        {
            return await _rolesRepository.GetAllRoles();
        }
    }
}
