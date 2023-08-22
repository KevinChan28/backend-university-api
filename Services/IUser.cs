using Api_backend_university.DTO;
using Api_backend_university.SecurityJWT;

namespace Api_backend_university.Services
{
    public interface IUser
    {
        Task<UserTokens> ValidateCredentials(Login login);
        Task<int> Register(UserRegister model);
        Task<List<User>> GetAllUsers();
    }
}
