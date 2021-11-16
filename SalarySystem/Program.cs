namespace SalarySystem
{
    internal class Program
    {
        private static void Main()
        {
            Setup.CreateAdminAccount();
            Menu.MainMenu();
        }
    }
}