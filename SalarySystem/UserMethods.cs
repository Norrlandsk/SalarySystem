using System;
using System.Linq;
using System.Threading;

namespace SalarySystem
{
    public static class UserMethods
    {
        public static User CreateUserAccount(Tuple<string, string, string> verifiedCredentials)
        {
            User user = new User();
            user.Username = verifiedCredentials.Item1;
            user.Password = verifiedCredentials.Item2;
            user.CompanyRole = verifiedCredentials.Item3;

            return user;
        }

        public static Tuple<string, string, string> VerifyValidCredentials()
        {
            bool isValid = false;
            bool isAvailable = false;

            do
            {
                Console.WriteLine("New username: ");
                string newUsername = Console.ReadLine();
                Console.WriteLine("New password: ");
                string newPassword = Console.ReadLine();

                if (newUsername.Any(char.IsLetter) &&
                newUsername.Any(char.IsDigit) &&
                newPassword.Any(char.IsLetter) &&
                newPassword.Any(char.IsDigit))
                {
                    foreach (var account in Account.listOfAccounts)
                    {
                        if (newUsername == account.Username)
                        {
                            Console.WriteLine("That username is already taken!");
                        }
                        else
                        {
                            isAvailable = true;
                            isValid = true;
                            Console.WriteLine("New role: ");
                            string companyRole = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Account has been created!");
                            return Tuple.Create(newUsername, newPassword, companyRole);
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Account credentials must contain both letters and digits!");
                    Thread.Sleep(1200);
                    Console.Clear();
                }
            } while (!isValid || !isAvailable);
            return null;
        }

        // Test that the user's id does not exist in the list afterwards
        public static Account RemoveUserAccount(Account account, Tuple<string, string> accountCredentials)
        {
            if (account.Username == accountCredentials.Item1 && account.Password == accountCredentials.Item2 && !account.IsAdmin)
            {
                var userToRemove = Account.listOfAccounts.FirstOrDefault(x => x.AccountId == account.AccountId);
                Account.listOfAccounts.Remove(userToRemove);
                Console.WriteLine("User removed!");
                account = null;
                return account;
            }
            Console.WriteLine("Something went wrong!");
            return account;
        }
    }
}