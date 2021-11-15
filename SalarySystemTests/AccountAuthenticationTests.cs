using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class AccountAuthenticationTests
    {
        private static User user = new();

        [ClassInitialize]
        public static void Startup(TestContext testContext)
        {
            user.Username = "elias";
            user.Password = "hjelm";
            user.CompanyRole = "janitor";
            user.IsOnline = false;

            Account.listOfAccounts.Add(user);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Account.listOfAccounts.Remove(user);
            user = null;
        }

        [TestMethod()]
        public void LoginTest_ShouldReturnTrue_WhenGivenValidCredentials()
        {
            AccountAuthentication.Login(Tuple.Create("elias", "hjelm"));

            Assert.IsTrue(user.IsOnline);
        }

        [TestMethod()]
        public void LoginTest_ShouldReturnFalse_WhenGivenInvalidUsername()
        {
            AccountAuthentication.Login(Tuple.Create("viktor", "hjelm"));

            Assert.IsFalse(user.IsOnline);
        }

        [TestMethod()]
        public void LoginTest_ShouldReturnFalse_WhenGivenInvalidPassword()
        {
            AccountAuthentication.Login(Tuple.Create("elias", "tomten"));

            Assert.IsFalse(user.IsOnline);
        }

        [TestMethod()]
        public void LogoutTest_ShouldReturnFalse_WhenAccountIsNotNullAndIsOnline()
        {
            AccountAuthentication.Logout(user);

            Assert.IsFalse(user.IsOnline);
        }
    }
}