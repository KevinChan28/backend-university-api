using Api_backend_university.DTO;
using Api_backend_university.Repository;

namespace Api_backend_university.Services.Imp
{
    public class ImpCourse : ICourse
    {
        private ICourseRepository _courseRepository;
        private IEventRepository _eventRepository;

        public ImpCourse(ICourseRepository courseRepository, IEventRepository eventRepository)
        {
            _courseRepository = courseRepository;
            _eventRepository = eventRepository;
        }


        public async Task<List<InformationCourse>> GetAllCourses()
        {
            List<Course> courses = await _courseRepository.GetAllCourses();
            List<InformationCourse> informationCourses = courses.Select(x => new InformationCourse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                EventId = x.EventId,
                Semester = x.Semester,
                Event = new InformationEvent
                {
                    Id = x.Event.Id,
                    CratedDate = x.Event.CratedDate,
                    CreatedBy = x.Event.CreatedBy,
                    UpdatedBy = x.Event.UpdatedBy,
                    UpdatedDate = x.Event.UpdatedDate
                }

            }).ToList();

            return informationCourses;
        }

        public async Task<int> RegisterCourse(CourseRegister courseRegister)
        {
            Event newEvent = new Event
            {
                CratedDate = DateTime.Now,
                CreatedBy = courseRegister.Event.CreatedBy,
                UpdatedBy = courseRegister.Event.UpdatedBy,
                UpdatedDate= DateTime.Now
            };
            int EventId = await _eventRepository.RegisterEvent(newEvent);

            if (EventId > 0)
            {
                Course courseNew = new Course
                {
                    Name = courseRegister.Name,
                    Description = courseRegister.Description,
                    EventId = EventId,
                    Semester = courseRegister.Semester,
                };
                int IdCourse = await _courseRepository.RegisterCourse(courseNew);

                return IdCourse;
            }

            return 0;
        }
    }
}
