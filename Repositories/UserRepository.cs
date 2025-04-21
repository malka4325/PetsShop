using Entities;
using System.IO;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository
    {
        public string path = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");
        public User getUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(path))
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
        public User login(UserLogin userLogin)
        {
           
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserName == userLogin.UserName && user.Password == userLogin.Password)
                        return user;
                }
            }
            return null;
        }
        public User addUser(User user)
        {
            if (user == null) return null;
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return user;
        }
        public void updateUser(int id,User userToUpdate)
        {

            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(path, text);
            }
        }
    }
}
