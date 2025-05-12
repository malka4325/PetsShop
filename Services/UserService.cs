using Entities;
using Repositories;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Zxcvbn;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository ;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> getUserById(int id)
        {
            return await _userRepository.getUserById(id);
        }
        public async Task<User> login(UserLogin userLogin)
        {
            if (userLogin == null) return null;
            return await _userRepository.login(userLogin);
        }
        public async Task<User> addUser(User user)
        {
            if (user == null) return null;

            return await _userRepository.addUser(user);
        }
        public async Task<User> updateUser(int id, User user)
        {
            if (user == null) return null;
           return await _userRepository.updateUser(id, user);
        }
        public int checkPassPower(string password)
        {
            if (password == null) return -1;
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}
