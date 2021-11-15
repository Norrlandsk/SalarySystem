namespace SalarySystem
{
    public interface IAccount
    {
        public int AccountId { get; set; }
        public string CompanyRole { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOnline { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}