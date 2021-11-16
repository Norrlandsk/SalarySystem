using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarySystem;
using SalarySystem.Tests;
using System;

namespace SalarySystemTests
{
    [TestClass()]
    public class IntegrationTests
    {
        private static User mockUser = new();

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
          2. Login user
          3. Logout user
        */
        public static User userPlaceholder = new();

        [TestMethod()]
        public void CreateUserAccountTest_ShouldHaveUniqueId()
        {
            var expected = mockUser;
            var actual = UserMethods.CreateUserAccount(Tuple.Create("elias", "hjelm", "janitor"));
            Assert.AreNotEqual(expected.AccountId, actual.AccountId);
            userPlaceholder = actual;
        }

        [TestMethod()]
        public void LoginTest_ShouldReturnTrue_WhenGivenValidCredentials()
        {
            Console.WriteLine($"{userPlaceholder.IsOnline}");

            AccountAuthentication.Login(userPlaceholder, Tuple.Create(userPlaceholder.Username, userPlaceholder.Password));

            Assert.IsTrue(userPlaceholder.IsOnline);
        }

        [TestMethod()]
        public void LogoutTest_ShouldReturnFalse_WhenAccountIsNotNullAndIsOnline()
        {
            Console.WriteLine($"{userPlaceholder.IsOnline}");
            AccountAuthentication.Logout(userPlaceholder);

            Assert.IsFalse(userPlaceholder.IsOnline);
        }
    }
}