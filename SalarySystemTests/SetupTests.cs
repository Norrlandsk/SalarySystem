using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class SetupTests
    {
        [TestMethod()]
        public void CreateAdminAccountTest()
        {
            var admin = Setup.CreateAdminAccount();
            Admin adminTest = new Admin("admin1", "admin1234", 25000, "IT-support");

            var expectedUsername = adminTest.Username;
            var actualUsername = admin.Username;
            Assert.AreEqual(expectedUsername, actualUsername);

            var expectedPassword = adminTest.Password;
            var actualPassword = admin.Password;
            Assert.AreEqual(expectedPassword, actualPassword);

            var expectedSalary = adminTest.Salary;
            var actualSalary = admin.Salary;
            Assert.AreEqual(expectedSalary, actualSalary);

            var expectedRole = adminTest.CompanyRole;
            var actualRole = admin.CompanyRole;
            Assert.AreEqual(expectedRole, actualRole);
        }
    }
}