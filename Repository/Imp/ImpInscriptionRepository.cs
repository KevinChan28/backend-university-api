using Api_backend_university.ContextDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api_backend_university.Repository.Imp
{
    public class ImpInscriptionRepository : IInscriptionRepository
    {
        UniversityDb2Context _universityDb;

        public ImpInscriptionRepository(UniversityDb2Context universityDb)
        {
            _universityDb = universityDb;
        }


        public async Task<int> AddStudentToClass(Inscription inscription)
        {
            bool existStudent = _universityDb.Students.Any(a => a.Id == inscription.StudentId);
            bool existCourse = _universityDb.Courses.Any(a => a.Id == inscription.ClassId);

            if (existStudent && existCourse)
            {
                EntityEntry<Inscription> newInscription = _universityDb.Inscriptions.Add(inscription);
                await _universityDb.SaveChangesAsync();

                return newInscription.Entity.Id;
            }

            return 0;
        }

        public async Task<List<Inscription>> GetAllClassesToStudent(int studentId)
        {
            return _universityDb.Inscriptions.Include(a => a.Class).Where(i => i.StudentId == studentId).AsEnumerable<Inscription>().ToList();
        }
    }
}
