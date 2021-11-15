namespace SalarySystem
{
    public class User : Account
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User()
        {
            
        }
    }
}