using System.Collections.Generic;

namespace SalarySystem
{
    public class Account
    {
        public static List<Account> listOfAccounts = new();
        public string Username { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }
        public string CompanyRole { get; set; }
        public bool IsAdmin { get; set; }
    }
}
