using Api_backend_university.DTO;
using Api_backend_university.Repository;

namespace Api_backend_university.Services.Imp
{
    public class ImpCareer : ICareer
    {
        ICareerRepository _careerRepository;

        public ImpCareer(ICareerRepository careerRepository)
        {
            _careerRepository = careerRepository;
        }

        public async Task<List<Career>> GetAllCareers()
        {
            return await _careerRepository.GetAllCareers();
        }

        public async Task<int> Register(CareerRegister model)
        {
            Career newCareer = new Career
            {
              Name = model.Name,
              Description = model.Description
            };
            int idCareer = await _careerRepository.Register(newCareer);

            return idCareer;
        }
    }
}
