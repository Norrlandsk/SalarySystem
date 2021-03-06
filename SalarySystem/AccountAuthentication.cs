using System;
using System.Collections.Generic;

namespace SalarySystem
{
    public static class AccountAuthentication
    {
        public static Tuple<string, string> AskForAccountCredentials()
        {
            Console.WriteLine("Enter username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            var password = Console.ReadLine();

            return Tuple.Create(username, password);
        }

        public static Account Login(Account accountPlaceholder, Tuple<string, string> loginCredentials, List<Account> listOfAccounts)
        {
            foreach (var account in listOfAccounts)
            {
                if (loginCredentials.Item1 == account.Username && loginCredentials.Item2 == account.Password)
                {
                    account.IsOnline = true;
                    Console.WriteLine("You have logged in!");
                    return account;
                }
            }
            Console.WriteLine("Something went terribly wrong! There is no account with those credentials!");
            return accountPlaceholder;
        }

        public static Account Logout(Account account)
        {
            if (account?.IsOnline == true)
            {
                account.IsOnline = false;
                return account;
            }
            return account;
        }
    }
}