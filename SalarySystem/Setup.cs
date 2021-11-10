namespace SalarySystem
{
    public static class Setup
    {
        public static Admin CreateAdminAccount()
        {
            return (Admin)(new("admin1", "admin1234", 25000, "IT-support"));
        }
    }
}