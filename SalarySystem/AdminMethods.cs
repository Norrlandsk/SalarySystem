using System;

namespace SalarySystem
{
    public static class AdminMethods
    {
        public static void AdminListOfUsers()
        {
            if (Account.listOfAccounts.Count > 1)
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
            else
            {
                Console.WriteLine("You are alone in this company!");
            }
        }

        public static User AdminCreateUser(Account account)
        {
            if (account.IsAdmin)
            {
                var user = UserMethods.CreateUserAccount(UserMethods.VerifyValidCredentials());
                Console.Clear();
                Console.WriteLine("User has been created!");
                return user;
            }
            return null;
        }

        public static bool AdminRemoveUser(Account account)
        {
            bool IsDeleted = false;

            if (account.IsAdmin)
            {
                var credentials = AccountAuthentication.AskForAccountCredentials();

                foreach (var user in Account.listOfAccounts)
                {
                    if (credentials.Item1 == user.Username && credentials.Item2 == user.Password && !user.IsAdmin)
                    {
                        Account.listOfAccounts.Remove(user);
                        Console.Clear();
                        Console.WriteLine("User has been removed!");
                        IsDeleted = true;
                        break;
                    }
                }
            }
            return IsDeleted;
        }
    }
}