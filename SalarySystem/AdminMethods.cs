using System;
using System.Collections.Generic;

namespace SalarySystem
{
    public static class AdminMethods
    {
        public static void AdminListOfUsers(List<Account> listOfAccounts)
        {
            if (listOfAccounts.Count > 1)
            {
                foreach (var account in listOfAccounts)
                {
                    if (account.IsAdmin)
                    {
                        continue;
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
                var user = UserMethods.CreateUserAccount(UserMethods.VerifyValidCredentials(Account.listOfAccounts));
                Console.Clear();
                Console.WriteLine("User has been created!");
                return user;
            }
            return null;
        }

        public static bool AdminRemoveUser(Account account, List<Account> listOfAccounts)
        {
            bool IsDeleted = false;

            if (account.IsAdmin)
            {
                var credentials = AccountAuthentication.AskForAccountCredentials();

                foreach (var user in listOfAccounts)
                {
                    if (credentials.Item1 == user.Username && credentials.Item2 == user.Password && !user.IsAdmin)
                    {
                        listOfAccounts.Remove(user);
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