namespace Entities
{
    public class UserLogin
    {
        public string Email  { get; set; }
        public string Password { get; set; }
        public UserLogin()
        {
            
        }
        public UserLogin(string userName, string password)
        {
            Email =userName;
            Password = password;
        }
    }
}
