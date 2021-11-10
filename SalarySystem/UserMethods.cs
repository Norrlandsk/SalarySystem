using System;
using System.Linq;

namespace SalarySystem
{
    public static class UserMethods
    {
        // Test that the properties are correctly set
        public static User CreateUserAccount()
        {
            //if (username.Any(char.IsLetter) && username.Any(char.IsDigit))
            //{
            //    if (password.Any(char.IsLetter) && password.Any(char.IsDigit))
            //    {
            //        User user = new User();
            //        user.Username = username;
            //        user.Password = password;
            //        user.Salary = salary;
            //        user.CompanyRole = role;

            //        return user;
            //    }
            //}
            return null;
        }

        // Test that the user's id does not exist in the list afterwards
        public static bool RemoveUserAccount(Account account, Tuple<string, string> accountCredentials)
        {
            if (account.Username == accountCredentials.Item1 && account.Password == accountCredentials.Item2)
            {
                var userToRemove = Account.listOfAccounts.FirstOrDefault(x => x.AccountId == account.AccountId);
                Account.listOfAccounts.Remove(userToRemove);
                Console.WriteLine("User removed!");
                return true;
            }
            Console.WriteLine("Something went wrong!");
            return false;
        }
    }
}