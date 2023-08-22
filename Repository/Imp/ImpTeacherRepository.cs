using Api_backend_university.ContextDB;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api_backend_university.Repository.Imp
{
    public class ImpTeacherRepository : ITeacherRepository
    {
        UniversityDb2Context _universityDb;

        public ImpTeacherRepository(UniversityDb2Context universityDb)
        {
            _universityDb = universityDb;
        }


        public async Task<List<Teacher>> GetAllTeachers()
        {
            return _universityDb.Teachers.AsEnumerable<Teacher>().ToList();
        }

        public async Task<int> Register(Teacher teacher)
        {
            EntityEntry<Teacher> teacherNew = _universityDb.Add(teacher);
            await _universityDb.SaveChangesAsync();

            return teacherNew.Entity.Id;
        }
    }
}
