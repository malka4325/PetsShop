namespace PetsShop
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        private static int code = 1;
        public User(string FirstName, string LastName, string UserName, string Password)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Password = Password;
            UserId = code++;
        }
    }
}
