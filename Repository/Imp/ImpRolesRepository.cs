using Api_backend_university.ContextDB;

namespace Api_backend_university.Repository.Imp
{
    public class ImpRolesRepository : IRolesRepository
    {
        UniversityDb2Context _universityDb;

        public ImpRolesRepository(UniversityDb2Context universityDb)
        {
            _universityDb = universityDb;
        }


        public async Task<List<Role>> GetAllRoles()
        {
            return _universityDb.Roles.AsEnumerable<Role>().ToList();
        }
    }
}
