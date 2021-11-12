using System;

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

        public static Account Login(Tuple<string, string> loginCredentials)
        {
            foreach (var account in Account.listOfAccounts)
            {
                if (loginCredentials.Item1 == account.Username && loginCredentials.Item2 == account.Password)
                {
                    account.IsOnline = true;
                    return account;
                }
            }
            return null;
        }

        public static bool Logout(Account account)
        {
            if (account != null)
            {
                account.IsOnline = false;
                return true;
            }

            return false;
        }
    }
}