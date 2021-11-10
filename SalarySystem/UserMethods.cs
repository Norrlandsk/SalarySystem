using System;
using System.Linq;

namespace SalarySystem
{
    public static class UserMethods
    {
        // Test that the properties are correctly set
        public static User CreateUserAccount()
        {
            Console.WriteLine("New username: ");
            string newUsername = Console.ReadLine();
            Console.WriteLine("New password: ");
            string newPassword = Console.ReadLine();

            VerifyValidCredentials(new)

            if (username.Any(char.IsLetter) && username.Any(char.IsDigit))
            {
                if (password.Any(char.IsLetter) && password.Any(char.IsDigit))
                {
                    User user = new User();
                    user.Username = username;
                    user.Password = password;
                    user.Salary = salary;
                    user.CompanyRole = role;

                    return user;
                }
            }
            return null;
        }

        private static bool VerifyValidCredentials(string username, string password)
        {
            bool isValid = false;

            return isValid;
        }

        // Test that the user's id does not exist in the list afterwards
        public static bool RemoveUserAccount(User user)
        {
            var username = Console.ReadLine();
            if (user.Username == username)
            {
                var userToRemove = User.listOfUsers.FirstOrDefault(x => x.UserId == user.UserId);
                User.listOfUsers.Remove(userToRemove);
                return true;
            }
            return false;
        }
    }
}