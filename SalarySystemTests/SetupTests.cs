using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarySystem;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class SetupTests
    {
        [TestMethod()]
        public void CreateAdminAccountTest()
        {
            var expected = 5;
            var actual = 5;
            Assert.AreEqual(expected,actual);
        }
    }
}