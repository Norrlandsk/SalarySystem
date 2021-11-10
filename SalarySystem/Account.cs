using System.Collections.Generic;

namespace SalarySystem
{
    public abstract class Account
    {
        public static List<Account> listOfAccounts = new();
        private static int idCounter;

        public Account()
        {
            idCounter++;
            AccountId = idCounter;
        }

        public int AccountId { get; set; }
        public string CompanyRole { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOnline { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }
        public string Username { get; set; }
    }
}