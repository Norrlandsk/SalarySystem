using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class AccountAuthenticationTests
    {
        private static User user = new();

        //FRÅGA: Bra practice att ha detta, eller skapa upp objekt i varje testmetod istället
        [TestInitialize]
        public void Startup()
        {
            user.Username = "elias";
            user.Password = "hjelm";
            user.CompanyRole = "janitor";
            user.IsOnline = false;

            Account.listOfAccounts.Add(user);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Account.listOfAccounts.Remove(user);
        }

        [TestMethod()]
        public void LoginTest_ShouldReturnTrue_WhenGivenValidCredentials()
        {
            AccountAuthentication.Login(user, Tuple.Create(user.Username, user.Password));

            Assert.IsTrue(user.IsOnline);
        }

        [TestMethod()]
        public void LoginTest_ShouldReturnFalse_WhenGivenInvalidUsername()
        {
            AccountAuthentication.Login(user, Tuple.Create("viktor", "hjelm"));

            Assert.IsFalse(user.IsOnline);
        }

        [TestMethod()]
        public void LoginTest_ShouldReturnFalse_WhenGivenInvalidPassword()
        {
            AccountAuthentication.Login(user, Tuple.Create("elias", "tomten"));

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