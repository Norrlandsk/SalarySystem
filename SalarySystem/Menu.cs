namespace SalarySystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Menu
    {
        public static Account accountPlaceholder;

        public static void MainMenu()
        {
            bool isRunning = true;
            int userInput;

            while (isRunning)
            {
                if (accountPlaceholder != null && accountPlaceholder.IsOnline)
                {
                    Console.WriteLine($"Logged in as: {accountPlaceholder.Username}\n");
                }

                Console.WriteLine("[1] Login");
                Console.WriteLine("[2] Create account");
                Console.WriteLine("[3] Check salary");
                Console.WriteLine("[4] Check company role");
                Console.WriteLine("[5] Remove your account");
                Console.WriteLine("[6 ADMIN] List accounts");
                Console.WriteLine("[7 ADMIN] Create user account");
                Console.WriteLine("[8 ADMIN] Remove user account");
                Console.WriteLine("[9] Logout");
                Console.WriteLine("[10] Exit");
                userInput = Utils.ConfirmCorrectInput(10);

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        accountPlaceholder = AccountAuthentication.Login(accountPlaceholder, AccountAuthentication.AskForAccountCredentials());

                        Utils.ContinueAndClear();
                        break;

                    case 2:
                        Console.Clear();
                        AccountMethods.AddAccountToAccountsList(UserMethods.CreateUserAccount(UserMethods.VerifyValidCredentials()));
                        Utils.ContinueAndClear();
                        break;

                    case 3:
                        Console.Clear();
                        if (accountPlaceholder != null && accountPlaceholder.IsOnline)
                        {
                            AccountMethods.ShowSalary(accountPlaceholder);
                            Utils.ContinueAndClear();
                        }
                        else
                        {
                            Console.WriteLine("You have to log in!");
                            Utils.ContinueAndClear();
                        }
                        break;

                    case 4:
                        Console.Clear();
                        if (accountPlaceholder != null && accountPlaceholder.IsOnline)
                        {
                            AccountMethods.ShowCompanyRole(accountPlaceholder);
                            Utils.ContinueAndClear();
                        }
                        else
                        {
                            Console.WriteLine("You have to log in!");
                            Utils.ContinueAndClear();
                        }
                        break;

                    case 5:
                        Console.Clear();
                        if (accountPlaceholder != null && accountPlaceholder.IsOnline)
                        {
                            accountPlaceholder = UserMethods.RemoveUserAccount(accountPlaceholder, AccountAuthentication.AskForAccountCredentials());
                            Utils.ContinueAndClear();
                        }
                        else
                        {
                            Console.WriteLine("You have to log in!");
                            Utils.ContinueAndClear();
                        }
                        break;

                    case 6:
                        Console.Clear();
                        if (accountPlaceholder != null && accountPlaceholder.IsAdmin)
                        {
                            AdminMethods.AdminListOfUsers();
                            Utils.ContinueAndClear();
                        }
                        else
                        {
                            Console.WriteLine("You have to be administrator!");
                            Utils.ContinueAndClear();
                        }
                        break;

                    case 7:
                        Console.Clear();
                        if (accountPlaceholder != null && accountPlaceholder.IsAdmin)
                        {
                            AccountMethods.AddAccountToAccountsList(AdminMethods.AdminCreateUser(accountPlaceholder));
                            Utils.ContinueAndClear();
                        }
                        else
                        {
                            Console.WriteLine("You have to be administrator!");
                            Utils.ContinueAndClear();
                        }
                        break;

                    case 8:
                        Console.Clear();
                        if (accountPlaceholder != null && accountPlaceholder.IsAdmin)
                        {
                            AdminMethods.AdminRemoveUser(accountPlaceholder);
                            Utils.ContinueAndClear();
                        }
                        else
                        {
                            Console.WriteLine("You have to be administrator!");
                            Utils.ContinueAndClear();
                        }
                        break;

                    case 9:
                        Console.Clear();
                        if (accountPlaceholder != null && accountPlaceholder.IsOnline)
                        {
                            accountPlaceholder = AccountAuthentication.Logout(accountPlaceholder);
                            Console.WriteLine("You have logged out!");
                            Utils.ContinueAndClear();
                        }
                        else
                        {
                            Console.WriteLine("You have to log in to log out!");
                            Utils.ContinueAndClear();
                        }
                        break;

                    case 10:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}