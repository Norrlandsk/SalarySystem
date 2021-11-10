using System.Collections.Generic;

namespace SalarySystem
{
    public class User : Account
    {
        public static List<User> listOfUsers = new();
        private static int idCounter;

        public User()
        {
            idCounter++;
            UserId = idCounter;
        }

        public int UserId { get; set; }
    }
}