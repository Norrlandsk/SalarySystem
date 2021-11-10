using System;
using System.Linq;

namespace SalarySystem
{
    public class UserMethods
    {
        // Test that the properties are correctly set
        public User CreateUserAccount()
        {
            return null;
        }

        // Test that the user's id does not exist in the list afterwards
        public bool RemoveUserAccount(User user)
        {
            var username = Console.ReadLine();
            if(user.Username == username)
            {
                var userToRemove = User.listOfUsers.FirstOrDefault(x => x.UserId == user.UserId);
                User.listOfUsers.Remove(userToRemove);
                return true;
            }
            return false;
        }
    }
}