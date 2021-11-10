namespace SalarySystem
{
    public class Admin : Account
    {
        public Admin(string username, string password, int salary, string companyRole)
        {
            Username = username;
            Password = password;
            Salary = salary;
            CompanyRole = companyRole;
            IsAdmin = true;
        }
    }
}