using Api_backend_university.DTO;
using Api_backend_university.Repository;

namespace Api_backend_university.Services.Imp
{
    public class ImpInscription : IInscription
    {
        IInscriptionRepository _inscriptionRepository;

        public ImpInscription(IInscriptionRepository inscriptionRepository)
        {
            _inscriptionRepository = inscriptionRepository;
        }


        public async Task<int> AddStudentToCourse(InscriptionRegister inscriptionRegister)
        {
            Inscription inscription = new Inscription
            {
                CreatedDate = DateTime.Now,
                ClassId = inscriptionRegister.ClassId,
                StudentId = inscriptionRegister.StudentId,
                IsInscribed = true,
            };
            int idInscription = await _inscriptionRepository.AddStudentToClass(inscription);

            return idInscription;
        }

        public async Task<List<ClassInformation>> GetAllCoursesToStudent(int studentId)
        {
            List<Inscription> coursesOfStudent = await _inscriptionRepository.GetAllClassesToStudent(studentId);
            List<ClassInformation> informationCourses = coursesOfStudent.Select(x => new ClassInformation
            {
               Id = x.Class.Id,
               EndTime = x.Class.EndTime,
               StartTime = x.Class.StartTime,
               Days = x.Class.Days,
               Course = new InfoCourseOfStudent
               {
                   Name = x.Class.Course.Name,
                   Description = x.Class.Course.Description,
               },
               Teacher = new TeacherInformation
               {
                   Name = x.Class.Teacher.Name
               }
            }).ToList();

            return informationCourses;
        }
    }
}
