using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<User> addUser(User user);
        int checkPassPower(string password);
        Task<User> getUserById(int id);
        Task<User> login(UserLogin userLogin);
        Task<User> updateUser(int id, User user);
    }
}