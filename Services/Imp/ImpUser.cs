using Api_backend_university.DTO;
using Api_backend_university.Helpers;
using Api_backend_university.Repository;
using Api_backend_university.SecurityJWT;

namespace Api_backend_university.Services.Imp
{
    public class ImpUser : IUser
    {
        IUserRepository _userRepository;
        JwtSettings _jwtSettings;

        public ImpUser(IUserRepository userRepository, JwtSettings jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings;
        }


        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<int> Register(UserRegister model)
        {
            User userNew = new User
            {
                Email = model.Email,
                Password = Encrypt.GetSHA256(model.Password),
                RolId = model.RolId,
            };
            int idUser = await _userRepository.Register(userNew);

            return idUser;
        }

        public async Task<UserTokens> ValidateCredentials(Login login)
        {
            UserTokens token = new UserTokens();

            User user = new User
            {
                Email = login.Email,
                Password = Encrypt.GetSHA256(login.Password)
            };
            bool validate = await _userRepository.ValidateCredentials(user);

            if (validate)
            {
                User userValidate = await _userRepository.GetUserByCredentials(user);
                UserTokens informationUser = new UserTokens
                {
                    UserName = userValidate.Email,
                    EmailId = userValidate.Email,
                    Id = userValidate.Id,
                    Rol = userValidate.RolId,
                    GuidId = Guid.NewGuid(),
                };
                token = JwtHelpers.GenerateToken(informationUser, _jwtSettings);

                return token;
            }
            return null;
        }
    }
}
