using Entities;
using Repositories;
using System.Linq.Expressions;
using Zxcvbn;

namespace Services
{
    public class UserService
    {
        private UserRepository userRepository = new UserRepository();
        public User getUserById(int id)
        {
            return userRepository.getUserById(id);
        }
        public User login(UserLogin userLogin)
        {
            if (userLogin == null) return null;
            return userRepository.login(userLogin);
        }
        public User addUser(User user)
        {
            if (user == null) return null;
            return userRepository.addUser(user);
        }
        public void updateUser(int id,User user)
        {
            if (user == null) return ;
            userRepository.updateUser(id,user);
        }
        public int checkPassPower(string password)
        {
            if (!string.IsNullOrEmpty(password)) return -1;
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}
