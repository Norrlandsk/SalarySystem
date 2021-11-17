namespace SalarySystem
{
    internal static class Program
    {
        private static void Main()
        {
            Setup.CreateAdminAccount();
            Menu.MainMenu();
        }
    }
}