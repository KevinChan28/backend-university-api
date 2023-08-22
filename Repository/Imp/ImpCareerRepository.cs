using Api_backend_university.ContextDB;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api_backend_university.Repository.Imp
{
    public class ImpCareerRepository : ICareerRepository
    {
        UniversityDb2Context _universityDb;

        public ImpCareerRepository(UniversityDb2Context universityDb)
        {
            _universityDb = universityDb;
        }

        public async Task<List<Career>> GetAllCareers()
        {
            return _universityDb.Careers.AsEnumerable<Career>().ToList();
        }

        public async Task<int> Register(Career career)
        {
            EntityEntry<Career> careerNew = _universityDb.Careers.Add(career);
            await _universityDb.SaveChangesAsync();

            return careerNew.Entity.Id;
        }
    }
}
