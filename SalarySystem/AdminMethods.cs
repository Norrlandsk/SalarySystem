using System;

namespace SalarySystem
{
    public class AdminMethods
    {
        public void AdminListOfUsers()
        {
            foreach (var account in Account.listOfAccounts)
            {
                if (account.IsAdmin)
                {
                    continue; //Does this work?
                }
                Console.WriteLine($"Username: {account.Username} Password: {account.Password}");
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

                foreach (var user in Account.listOfAccounts)
                {
                    if (username == user.Username && password == user.Password)
                    {
                        Account.listOfAccounts.Remove(user);
                        IsDeleted = true;
                    }
                }
            }
            return IsDeleted;
        }
    }
}