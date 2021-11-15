using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class AccountAuthenticationTests
    {
        private static User user = new();

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

        [DataTestMethod()]
        [DynamicData(nameof(GetAccount), DynamicDataSourceType.Method)]
        public IAccount LoginTest_ShouldReturnTrue_WhenGivenValidCredentials(IAccount account)
        {
            AccountAuthentication.Login(Tuple.Create(account.Username, account.Password));

            Assert.IsTrue(account.IsOnline);
            

            return account;
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
        [DynamicData(nameof(GetAccount), DynamicDataSourceType.Method)]
        public Account LogoutTest_ShouldReturnFalse_WhenAccountIsNotNullAndIsOnline(Account account)
        {
            AccountAuthentication.Logout(account);

            Assert.IsFalse(account.IsOnline);

            return account;
        }

        private static IEnumerable<object[]> GetAccount()
        {
            //var acc = LoginTest_ShouldReturnTrue_WhenGivenValidCredentials(account);
            yield return new object[] { new User("elias", "hjelm")};
        }
    }
}