namespace SalarySystem
{
    public static class Setup
    {
        public static void CreateAdminAccount()
        {
            Account.listOfAccounts.Add((Admin)(new("admin1", "admin1234", 25000, "IT-support")));
        }
    }
}