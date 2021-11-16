using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarySystem;
using SalarySystem.Tests;

namespace SalarySystemTests
{
    [TestClass()]
    public class IntegrationTests
    {
        //private static User user = new();

        //[TestInitialize]
        //public void Startup()
        //{
        //    user.Username = "elias";
        //    user.Password = "hjelm";
        //    user.CompanyRole = "janitor";
        //    user.IsOnline = false;
        //}

        /*
          1. Create user
          2. Login user
          3.
          3. Logout user
        */
        public static User testUser = new();

        [TestMethod()]
        public void UserCreationAndLoginAndLogoutTest()
        {
        }
    }
}