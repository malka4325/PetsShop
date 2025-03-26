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
    }
}
