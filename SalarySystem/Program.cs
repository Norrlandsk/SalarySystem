namespace SalarySystem
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var admin = Setup.CreateAdminAccount();
            Account.listOfAccounts.Add(admin);
        }
    }
}
