using Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PetsShopContext _petsShopContext;

        public UserRepository(PetsShopContext petsShopContext)
        {
            _petsShopContext = petsShopContext;
        }

        public async Task<User> getUserById(int id)
        {
            User user = await _petsShopContext.Users.FindAsync(id);
            return user;

        }
        public async Task<User> login(UserLogin userLogin)
        {
           User userFound= await _petsShopContext.Users.Where(user=>user.Email==userLogin.Email && user.Password==userLogin.Password).FirstOrDefaultAsync();
            return userFound;
        }
        public async Task<User> addUser(User user)
        {
            await _petsShopContext.AddAsync(user);
            await _petsShopContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> updateUser(int id, User userToUpdate)
        
        {
           
           _petsShopContext.Users.Update(userToUpdate);
            await _petsShopContext.SaveChangesAsync();
            return userToUpdate;

        }
    }
}
