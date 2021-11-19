using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarySystem;
using System;
using System.Collections.Generic;

namespace SalarySystemTests
{
    [TestClass()]
    public class UserIntegrationTest
    {
        private static User mockUser = new();
        private static User userPlaceholder = new();
        private static List<Account> mockListOfAccounts = new();

        [ClassInitialize]
        public static void Startup(TestContext tc)
        {
            mockUser.Username = "elias";
            mockUser.Password = "hjelm";
            mockUser.CompanyRole = "janitor";
            mockUser.IsOnline = false;
        }

        /*
          1. Create user
          2. Add user to list
          3. Login user
          4. Logout user
        */

        [TestMethod(), TestCategory("Integration")]
        public void CreateUserAccountTest_ShouldHaveUniqueId()
        {
            var expected = mockUser;
            var actual = UserMethods.CreateUserAccount(Tuple.Create("elias", "hjelm", "janitor"));
            userPlaceholder = actual;

            Assert.AreNotEqual(expected.AccountId, actual.AccountId);
        }

        [TestMethod(), TestCategory("Integration")]
        public void AddAccountToAccountsListTest_ShouldAddAccountToList()
        {
            var oldListCount = mockListOfAccounts.Count;
            AccountMethods.AddAccountToAccountsList(userPlaceholder, mockListOfAccounts);
            var newListCount = mockListOfAccounts.Count;

            Assert.AreNotEqual(oldListCount, newListCount);
        }

        [TestMethod(), TestCategory("Integration")]
        public void LoginTest_ShouldReturnTrue_WhenGivenValidCredentials()
        {
            mockListOfAccounts.Add(userPlaceholder);
            AccountAuthentication.Login(userPlaceholder, Tuple.Create(userPlaceholder.Username, userPlaceholder.Password), mockListOfAccounts);

            Assert.IsTrue(userPlaceholder.IsOnline);
        }

        [TestMethod(), TestCategory("Integration")]
        public void LogoutTest_ShouldReturnFalse_WhenAccountIsNotNullAndIsOnline()
        {
            AccountAuthentication.Logout(userPlaceholder);

            Assert.IsFalse(userPlaceholder.IsOnline);
        }
    }
}