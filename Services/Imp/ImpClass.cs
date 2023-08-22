using Api_backend_university.DTO;
using Api_backend_university.Repository;

namespace Api_backend_university.Services.Imp
{
    public class ImpClass : IClass
    {
        IClassRepository _classRepository;

        public ImpClass(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }


        public async Task<List<Class>> GetAllClasses()
        {
            return await _classRepository.GetAllClasses();
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
