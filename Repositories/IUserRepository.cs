﻿using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
         Task<User> addUser(User user);
         Task<User> getUserById(int id);
         Task<User> login(UserLogin userLogin);
         Task<User> updateUser(int id, User userToUpdate);
    }
}