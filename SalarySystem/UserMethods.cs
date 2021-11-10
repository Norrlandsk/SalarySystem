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