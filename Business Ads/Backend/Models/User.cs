namespace Backend.Models
{
    public class User
    {
        public User()
        {
            Username = "";
            Password = "";
            Email = "";
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
