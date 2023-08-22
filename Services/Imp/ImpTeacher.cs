using Api_backend_university.DTO;
using Api_backend_university.Helpers;
using Api_backend_university.Repository;

namespace Api_backend_university.Services.Imp
{
    public class ImpTeacher : ITeacher
    {
        ITeacherRepository _teacherRepository;
        IUserRepository _userRepository;

        public ImpTeacher(ITeacherRepository teacherRepository, IUserRepository user)
        {
            _teacherRepository = teacherRepository;
            _userRepository = user;
        }


        public async Task<List<TeacherInformation>> GetAllTeachers()
        {
            List<Teacher> teachers = await _teacherRepository.GetAllTeachers();
            List<TeacherInformation> teacherInformation = teachers.Select(a => new TeacherInformation
            {
                IdTeacher = a.Id,
                Name = a.Name,
                LastName = a.LastName,
                Email = a.Email,
            }).ToList();

            return teacherInformation;
        }

        public async Task<int> RegisterTeacher(TeacherRegister model)
        {
            User user = new User
            {
                Email = model.User.Email,
                Password = Encrypt.GetSHA256(model.User.Password),
                RolId = model.User.RolId,
            };
            int UserId = await _userRepository.Register(user);

            if (UserId < 1)
            {
                return 0;
            }

            Teacher teacher = new Teacher
            {
                Name = model.Name,
                LastName = model.LastName,
                Email = model.User.Email,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Telephone = model.Telephone,
                UserId = UserId
            };
            int TeacherId = await _teacherRepository.Register(teacher);

            return TeacherId;
        }
    }
}
