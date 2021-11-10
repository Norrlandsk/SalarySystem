using System;

namespace SalarySystem
{
    public class AccountMethods
    {
        public void ShowSalary(Account account)
        {
            Console.WriteLine(account.Salary);
        }

        public void ShowCompanyRole(Account account)
        {
            Console.WriteLine(account.CompanyRole);
        }
    }
}