using System;

namespace SalarySystem
{
    public static class AccountMethods
    {
        public static void ShowSalary(Account account)
        {
            Console.WriteLine(account.Salary);
        }

        public static void ShowCompanyRole(Account account)
        {
            Console.WriteLine(account.CompanyRole);
        }

        public static void AddAccountToAccountsList(Account account)
        {
            Account.listOfAccounts.Add(account);
        }
    }
}