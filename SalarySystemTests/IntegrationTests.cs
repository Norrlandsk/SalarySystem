using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarySystem;
using SalarySystem.Tests;

namespace SalarySystemTests
{
    [TestClass()]
    public class IntegrationTests
    {
        //private static User user = new();

        //[TestInitialize]
        //public void Startup()
        //{
        //    user.Username = "elias";
        //    user.Password = "hjelm";
        //    user.CompanyRole = "janitor";
        //    user.IsOnline = false;
        //}

        /*
          1. Create user
          2. Login user
          3. Logout user
        */

        [TestMethod()]
        public void UserCreationAndLoginAndLogoutTest()
        {
            UserMethodsTests userMethodsTests = new();
            AccountAuthenticationTests accountAuthenticationTests = new();

            var user = userMethodsTests.CreateUserAccountTest_ShouldHaveUniqueId();
            AccountMethods.AddAccountToAccountsList(user);
            var loggedInUser = accountAuthenticationTests.LoginTest_ShouldReturnTrue_WhenGivenValidCredentials(user);

           // accountAuthenticationTests.LogoutTest_ShouldReturnFalse_WhenAccountIsNotNullAndIsOnline(loggedInUser);

            //accountAuthenticationTests.LogoutTest_ShouldReturnFalse_WhenAccountIsNotNullAndIsOnline(accountAuthenticationTests.GetAccount(loggedInUser));
        }
    }
}