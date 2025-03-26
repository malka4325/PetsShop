using Entities;
using System.IO;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository
    {
        public User getUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(Path.Combine(Directory.GetCurrentDirectory(), "users.txt")))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user.UserId == id)
                        return user;//write in c# code
                }
            }
           return null;//write in c# code
        }
    }
}
