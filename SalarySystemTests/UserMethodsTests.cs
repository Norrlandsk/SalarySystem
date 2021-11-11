using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class UserMethodsTests
    {
        [TestMethod()]
        public void CreateUserAccountTest_ShouldHaveUniqueId()
        {
            User user = new();
            user.Username = "elias";
            user.Password = "hjelm";
            user.CompanyRole = "janitor";

            var expected = user;
            var actual = UserMethods.CreateUserAccount(Tuple.Create("elias", "hjelm", "janitor"));
            Assert.AreNotEqual(expected.AccountId, actual.AccountId);
        }

        [TestMethod()]
        public void VerifyValidCredentialsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveUserAccountTest_ShouldRemoveUserAccountFromList_WhenValidCredentials()
        {
            User user = new();
            user.Username = "elias";
            user.Password = "hjelm";
            user.CompanyRole = "janitor";

            Account.listOfAccounts.Add(user);

            var oldListCount = Account.listOfAccounts.Count;
            UserMethods.RemoveUserAccount(user, Tuple.Create("elias", "hjelm"));
            var newListCount = Account.listOfAccounts.Count;

            Assert.AreNotEqual(oldListCount, newListCount);
        }

        [TestMethod()]
        public void RemoveUserAccountTest_ShouldNotRemoveUserAccountFromList_WhenInvalidCredentials()
        {
            User user = new();
            user.Username = "sofia";
            user.Password = "hjelm";
            user.CompanyRole = "janitor";

            Account.listOfAccounts.Add(user);

            var oldListCount = Account.listOfAccounts.Count;
            UserMethods.RemoveUserAccount(user, Tuple.Create("elias", "hjelm"));
            var newListCount = Account.listOfAccounts.Count;

            Assert.AreEqual(oldListCount, newListCount);
        }
    }
}