using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class AccountAuthenticationTests
    {
        private static User user = new();
        private static List<Account> mockListOfAccounts = new();

        //FRÅGA: Bra practice att ha detta, eller skapa upp objekt i varje testmetod istället
        [TestInitialize]
        public void Startup()
        {
            user.Username = "elias";
            user.Password = "hjelm";
            user.CompanyRole = "janitor";
            user.IsOnline = false;

            mockListOfAccounts.Add(user);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mockListOfAccounts.Remove(user);
        }

        [TestMethod(), TestCategory("Unit")]
        public void LoginTest_ShouldReturnTrue_WhenGivenValidCredentials()
        {
            AccountAuthentication.Login(user, Tuple.Create(user.Username, user.Password) , mockListOfAccounts);

            Assert.IsTrue(user.IsOnline);
        }

        [TestMethod(), TestCategory("Unit")]
        public void LoginTest_ShouldReturnFalse_WhenGivenInvalidUsername()
        {
            AccountAuthentication.Login(user, Tuple.Create("viktor", "hjelm"), mockListOfAccounts);

            Assert.IsFalse(user.IsOnline);
        }

        [TestMethod(), TestCategory("Unit")]
        public void LoginTest_ShouldReturnFalse_WhenGivenInvalidPassword()
        {
            AccountAuthentication.Login(user, Tuple.Create("elias", "tomten"), mockListOfAccounts);

            Assert.IsFalse(user.IsOnline);
        }

        [TestMethod(), TestCategory("Unit")]
        public void LogoutTest_ShouldReturnFalse_WhenAccountIsNotNullAndIsOnline()
        {
            AccountAuthentication.Logout(user);

            Assert.IsFalse(user.IsOnline);
        }
    }
}