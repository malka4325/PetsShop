using Entities;
using Repositories;

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
            return userRepository.login(userLogin);
        }
        public User addUser(User user)
        {
            return userRepository.addUser(user);
        }
        public void updateUser(int id,User user)
        {
            userRepository.updateUser(id,user);
        }
    }
}
