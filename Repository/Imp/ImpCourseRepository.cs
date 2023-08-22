using Api_backend_university.ContextDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api_backend_university.Repository.Imp
{
    public class ImpCourseRepository : ICourseRepository
    {
        UniversityDb2Context _universityDB;

        public ImpCourseRepository(UniversityDb2Context universityDB)
        {
            _universityDB = universityDB;
        }


        public async Task<List<Course>> GetAllCourses()
        {
            return _universityDB.Courses.Include(x => x.Event).AsEnumerable<Course>().ToList();
        }
        
        public async Task<int> RegisterCourse(Course course)
        {
            EntityEntry<Course> courseNew = _universityDB.Courses.Add(course);
            await _universityDB.SaveChangesAsync();

            return courseNew.Entity.Id;
        }
    }
}
