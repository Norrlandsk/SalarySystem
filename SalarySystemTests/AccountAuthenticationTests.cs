using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class AccountAuthenticationTests
    {
        [TestMethod()]
        public void LoginTest_ShouldReturnTrue_WhenGivenValidCredentials()
        {
            User user = new();
            user.Username = "elias";
            user.Password = "hjelm";
            user.CompanyRole = "janitor";

            Account.listOfAccounts.Add(user);
            AccountAuthentication.Login(Tuple.Create("elias", "hjelm"));

            Assert.IsTrue(user.IsOnline);
        }

        //[TestMethod()]
        //public void LoginTest_ShouldReturnFalse_WhenGivenInvalidCredentials()
        //{
        //    User user = new();
        //    user.Username = "elias";
        //    user.Password = "hjelm";
        //    user.CompanyRole = "janitor";

        //    Account.listOfAccounts.Add(user);
        //    AccountAuthentication.Login(Tuple.Create("viktor", "hjelm"));

        //    Assert.IsTrue(user.IsOnline);

        //}

        [TestMethod()]
        public void LogoutTest()
        {
            Assert.Fail();
        }
    }
}