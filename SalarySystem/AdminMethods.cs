using System;

namespace SalarySystem
{
    public class AdminMethods
    {
        public void AdminListOfUsers()
        {
            foreach (var user in User.listOfUsers)
            {
                Console.WriteLine($"Username: {user.Username} Password: {user.Password}");
            }
        }

        public User AdminCreateUser(Account account)
        {
            if (account.IsAdmin)
            {
                return UserMethods.CreateUserAccount();
            }
            return null;
        }

        public bool AdminRemoveUser(Account account)
        {
            bool IsDeleted = false;

            if (account.IsAdmin)
            {
                string username = "";
                string password = "";

                foreach (var user in User.listOfUsers)
                {
                    if (username == user.Username && password == user.Password)
                    {
                        User.listOfUsers.Remove(user);
                        IsDeleted = true;
                    }
                }
            }
            return IsDeleted;
        }
    }
}