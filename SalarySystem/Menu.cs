namespace SalarySystem
{
    using System;

    public static class Menu
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
                        accountPlaceholder = AccountAuthentication.Login(accountPlaceholder, AccountAuthentication.AskForAccountCredentials(), Account.listOfAccounts);

                        Utils.ContinueAndClear();
                        break;

                    case 2:
                        Console.Clear();
                        AccountMethods.AddAccountToAccountsList(UserMethods.CreateUserAccount(UserMethods.VerifyValidCredentials(Account.listOfAccounts)), Account.listOfAccounts);
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
                        if (accountPlaceholder != null && accountPlaceholder.IsOnline && !accountPlaceholder.IsAdmin)
                        {
                            accountPlaceholder = UserMethods.RemoveUserAccount(accountPlaceholder, AccountAuthentication.AskForAccountCredentials(), Account.listOfAccounts);
                            Utils.ContinueAndClear();
                        }
                        else if(accountPlaceholder != null && accountPlaceholder.IsAdmin)
                        {
                            Console.WriteLine("Admin is not allowed to do this.");
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
                        if (accountPlaceholder != null && accountPlaceholder.IsAdmin && accountPlaceholder.IsOnline)
                        {
                            AdminMethods.AdminListOfUsers(Account.listOfAccounts);
                            Utils.ContinueAndClear();
                        }
                        else
                        {
                            Console.WriteLine("You have to be logged in as an administrator!");
                            Utils.ContinueAndClear();
                        }
                        break;

                    case 7:
                        Console.Clear();
                        if (accountPlaceholder != null && accountPlaceholder.IsAdmin && accountPlaceholder.IsOnline)
                        {
                            AccountMethods.AddAccountToAccountsList(AdminMethods.AdminCreateUser(accountPlaceholder), Account.listOfAccounts);
                            Utils.ContinueAndClear();
                        }
                        else
                        {
                            Console.WriteLine("You have to be logged in as an administrator!");
                            Utils.ContinueAndClear();
                        }
                        break;

                    case 8:
                        Console.Clear();
                        if (accountPlaceholder != null && accountPlaceholder.IsAdmin && accountPlaceholder.IsOnline)
                        {
                            AdminMethods.AdminRemoveUser(accountPlaceholder, Account.listOfAccounts);
                            Utils.ContinueAndClear();
                        }
                        else
                        {
                            Console.WriteLine("You have to be logged in as an administrator!");
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