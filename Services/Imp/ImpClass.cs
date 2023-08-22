using Api_backend_university.DTO;
using Api_backend_university.Repository;
using System.Collections.Generic;

namespace Api_backend_university.Services.Imp
{
    public class ImpClass : IClass
    {
        IClassRepository _classRepository;

        public ImpClass(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }


        public async Task<List<ClassInformation>> GetAllClasses()
        {
            List<Class> classes = await _classRepository.GetAllClasses();
            List<ClassInformation> classInformation = classes.Select(x => new ClassInformation
            {

                Id = x.Id,
                EndTime = x.EndTime,
                StartTime = x.StartTime,
                Days = x.Days,
                Course = new InfoCourseOfStudent
                {
                    IdCourse = x.Course.Id,
                    Name = x.Course.Name,
                    Description = x.Course.Description,
                    Semester = x.Course.Semester
                },
                Teacher = new TeacherInformation
                {
                    IdTeacher = x.Teacher.Id,
                    Name = x.Teacher.Name,
                    LastName = x.Teacher.LastName,
                    Email = x.Teacher.Email
                }
            }).ToList();

            return classInformation;
        }

        public async Task<int> RegisterClass(ClassRegister classRegister)
        {
            Class newClass = new Class
            {
                CourseId = classRegister.CourseId,
                Days = classRegister.Days,
                StartTime = classRegister.StartTime,
                EndTime = classRegister.EndTime,
                TeacherId = classRegister.TeacherId,
            };
            int ClassId = await _classRepository.RegisterClass(newClass);

            return ClassId;
        }
    }
}
