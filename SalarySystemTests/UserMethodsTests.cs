using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class UserMethodsTests
    {
        private static User userOne = new();
        private static User userTwo = new();

        [ClassInitialize]
        public static void Startup(TestContext testContext)
        {
            userOne.Username = "elias";
            userOne.Password = "hjelm";
            userOne.CompanyRole = "janitor";

            userTwo.Username = "sofia";
            userTwo.Password = "hjelm";
            userTwo.CompanyRole = "janitor";

            Account.listOfAccounts.Add(userOne);
            Account.listOfAccounts.Add(userTwo);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Account.listOfAccounts.Remove(userOne);
            Account.listOfAccounts.Remove(userTwo);

            userOne = null;
        }

        [TestMethod()]
        public void CreateUserAccountTest_ShouldHaveUniqueId()
        {
            var expected = userOne;
            var actual = UserMethods.CreateUserAccount(Tuple.Create("elias", "hjelm", "janitor"));
            Assert.AreNotEqual(expected.AccountId, actual.AccountId);
        }

        [TestMethod()]
        public void RemoveUserAccountTest_ShouldRemoveUserAccountFromList_WhenValidCredentials()
        {
            var oldListCount = Account.listOfAccounts.Count;
            UserMethods.RemoveUserAccount(userOne, Tuple.Create("elias", "hjelm"));
            var newListCount = Account.listOfAccounts.Count;

            Assert.AreNotEqual(oldListCount, newListCount);
        }

        [TestMethod()]
        public void RemoveUserAccountTest_ShouldNotRemoveUserAccountFromList_WhenInvalidCredentials()
        {
            var oldListCount = Account.listOfAccounts.Count;
            UserMethods.RemoveUserAccount(userTwo, Tuple.Create("elias", "hjelm"));
            var newListCount = Account.listOfAccounts.Count;

            Assert.AreEqual(oldListCount, newListCount);
        }
    }
}