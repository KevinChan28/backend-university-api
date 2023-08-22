using Api_backend_university.ContextDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api_backend_university.Repository.Imp
{
    public class ImpStudentRepository : IStudentRepository
    {
        UniversityDb2Context _universityDb;

        public ImpStudentRepository(UniversityDb2Context universityDb)
        {
            _universityDb = universityDb;
        }

        public async Task<List<Student>> GetAllStudentsWithCareer()
        {
            return await _universityDb.Students.Include(s => s.Career).ToListAsync();
        }

        public async Task<Student> GetStudentById(int idStudent)
        {
            return _universityDb.Students.Where(s => s.Id == idStudent).FirstOrDefault();
        }

        public async Task<int> Register(Student student)
        {
            EntityEntry<Student> studentNew = _universityDb.Students.Add(student);
               await _universityDb.SaveChangesAsync();
               
            return studentNew.Entity.Id;
        }
    }
}
