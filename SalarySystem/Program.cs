namespace SalarySystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var admin = Setup.CreateAdminAccount();
            Account.listOfAccounts.Add(admin);
        }
    }
}