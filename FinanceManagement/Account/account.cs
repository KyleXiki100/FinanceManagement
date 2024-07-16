namespace FinanceManagement.Account
{
    public abstract class Account
    {
        public int Id { get; protected set; }
        public string Username { get; protected set; }
        protected string PasswordHash { get; set; }

        public abstract bool Authenticate(string password);
        protected abstract string HashPassword(string password);

    }
    
    
}