using Api_backend_university.ContextDB;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api_backend_university.Repository.Imp
{
    public class ImpUserRepository : IUserRepository
    {
        UniversityDb2Context _universityDb;

        public ImpUserRepository(UniversityDb2Context universityDb)
        {
            _universityDb = universityDb;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return _universityDb.Users.AsEnumerable<User>().ToList();
        }

        public async Task<User> GetUserByCredentials(User user)
        {
            return _universityDb.Users.FirstOrDefault(a => a.Email == user.Email && a.Password == user.Password);
        }

        public async Task<int> Register(User user)
        {
            EntityEntry<User> userNew = _universityDb.Users.Add(user);
              await _universityDb.SaveChangesAsync();

            return userNew.Entity.Id;   
        }

        public async Task<bool> ValidateCredentials(User user)
        {
            return _universityDb.Users.Any(a => a.Email == user.Email && a.Password == user.Password);
        }
    }
}
