using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class UserMethodsTests
    {
        private static User userOne = new();
        private static User userTwo = new();
        private static List<Account> mockListOfAccounts = new();

        [TestInitialize]
        public void Startup()
        {
            userOne.Username = "elias";
            userOne.Password = "hjelm";
            userOne.CompanyRole = "janitor";

            userTwo.Username = "sofia";
            userTwo.Password = "hjelm";
            userTwo.CompanyRole = "janitor";

            mockListOfAccounts.Add(userOne);
            mockListOfAccounts.Add(userTwo);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mockListOfAccounts.Remove(userOne);
            mockListOfAccounts.Remove(userTwo);
        }

        [TestMethod(), TestCategory("Unit")]
        public void CreateUserAccountTest_ShouldHaveUniqueId()
        {
            var expected = userOne;
            var actual = UserMethods.CreateUserAccount(Tuple.Create("elias", "hjelm", "janitor"));
            Assert.AreNotEqual(expected.AccountId, actual.AccountId);
        }

        [TestMethod(), TestCategory("Unit")]
        public void RemoveUserAccountTest_ShouldRemoveUserAccountFromList_WhenValidCredentials()
        {
            var oldListCount = mockListOfAccounts.Count;
            UserMethods.RemoveUserAccount(userOne, Tuple.Create("elias", "hjelm"), mockListOfAccounts);
            var newListCount = mockListOfAccounts.Count;

            Assert.AreNotEqual(oldListCount, newListCount);
        }

        [TestMethod(), TestCategory("Unit")]
        public void RemoveUserAccountTest_ShouldNotRemoveUserAccountFromList_WhenInvalidCredentials()
        {
            var oldListCount = mockListOfAccounts.Count;
            UserMethods.RemoveUserAccount(userTwo, Tuple.Create("elias", "hjelm"), mockListOfAccounts);
            var newListCount = mockListOfAccounts.Count;

            Assert.AreEqual(oldListCount, newListCount);
        }
    }
}