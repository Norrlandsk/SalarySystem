using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class AccountMethodsTests
    {
        private static List<Account> mockListOfAccounts = new();

        [TestMethod()]
        public void AddAccountToAccountsListTest_ShouldAddAccountToList()
        {
            User userOne = new();

            var oldListCount = mockListOfAccounts.Count;
            AccountMethods.AddAccountToAccountsList(userOne, mockListOfAccounts);
            var newListCount = mockListOfAccounts.Count;

            Assert.AreNotEqual(oldListCount, newListCount);
        }
    }
}