namespace Api_backend_university.Repository
{
    public interface IUserRepository
    {
        Task<bool> ValidateCredentials(User user);
        Task<User> GetUserByCredentials(User user);
        Task<int> Register(User user);
        Task<List<User>> GetAllUsers();
    }
}
