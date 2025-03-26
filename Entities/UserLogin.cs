namespace Entities
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserLogin()
        {
            
        }
        public UserLogin(string userName, string password)
        {
            UserName=userName;
            Password = password;
        }
    }
}
