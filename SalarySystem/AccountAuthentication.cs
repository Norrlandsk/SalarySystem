namespace SalarySystem
{
    public class AccountAuthentication
    {
        public User Login()
        {
            var username = "";
            var password = "";
            foreach (var user in User.listOfUsers)
            {
                if (username == user.Username && password == user.Password)
                {
                    user.IsOnline = true;
                    return user;
                }
            }
            return null;
        }

        public void Logout(User user)
        {
            if(user != null)
            {
                user.IsOnline = false;
            }

        }
    }
}