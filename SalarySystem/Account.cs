namespace SalarySystem
{
    public abstract class Account
    {
        public bool IsOnline { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }
        public string CompanyRole { get; set; }
        public bool IsAdmin { get; set; }
    }
}