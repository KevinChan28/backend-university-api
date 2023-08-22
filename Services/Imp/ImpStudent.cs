using Api_backend_university.DTO;
using Api_backend_university.Helpers;
using Api_backend_university.Repository;

namespace Api_backend_university.Services.Imp
{
    public class ImpStudent : IStudent
    {
        IStudentRepository _studentRepository;
        IUserRepository _userRepository; 

        public ImpStudent(IStudentRepository student, IUserRepository user)
        {
            _studentRepository = student;
            _userRepository = user;
        }

        public async Task<List<StudentsWithCareer>> GetAllStudentsByCareer(int idCareer)
        {
            List<Student> students = await _studentRepository.GetAllStudentsWithCareer();
            List<StudentsWithCareer> studentsOfCareer = students.Where(i => i.CareerId == idCareer).Select(student => new StudentsWithCareer
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                CreatedDate = student.CreatedDate,
                DateOfBirth = student.DateOfBirth,
                Email = student.Email,
                Gender = student.Gender,
                Career = new CareerInformation
                {
                    Id = student.Career.Id,
                    Name = student.Career.Name,
                    Description = student.Career.Description
                },
                CareerId = student.CareerId,
                Telephone = student.Telephone,
                UserId = student.UserId
            }).ToList();

            return studentsOfCareer;
        }

        public async Task<List<StudentsWithCareer>> GetAllStudentsWithCareer()
        {
            List<Student> students = await _studentRepository.GetAllStudentsWithCareer();
            List<StudentsWithCareer> studentsWithCareer = students.Select(a => new StudentsWithCareer
            {
                Id = a.Id,
                Name = a.Name,
                LastName = a.LastName,
                CreatedDate = a.CreatedDate,
                DateOfBirth = a.DateOfBirth,
                Email = a.Email,
                Gender = a.Gender,
                Career = new CareerInformation
                {
                    Id = a.Career.Id,
                    Name = a.Career.Name,
                    Description = a.Career.Description
                },
                CareerId = a.CareerId,
                Telephone = a.Telephone,
                UserId = a.UserId
            }).ToList();

            return studentsWithCareer;
        }

        public async Task<int> Register(StudentRegister student)
        {
            User userRegister = new User
            {
                Email = student.User.Email,
                Password = Encrypt.GetSHA256(student.User.Password),
                RolId = student.User.RolId
            };

            int userId = await _userRepository.Register(userRegister);

            Student studentNew = new Student
            {
                Name = student.Name,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                CreatedDate = DateTime.Now,
                Email = student.User.Email,
                Gender = student.Gender,
                Telephone = student.Telephone,
                CareerId = student.CareerId,
                UserId = userId
            };

            int studentId = await _studentRepository.Register(studentNew);

            return studentId;
        }
    }
}
