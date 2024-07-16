using System;

namespace FinanceManagement.Account
{
    public class StandardAccount : Account
    {
        public StandardAccount(string username, string password)
        {
            Username = username;
            PasswordHash = HashPassword(password);
        }

        public override bool Authenticate(string password)
        {
            return PasswordHash == HashPassword(password);
        }

        protected override string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
        
        
        
    }

    public class AdminAccount : StandardAccount
    {
        public bool CanManageUsers { get; set; } = true;

        public AdminAccount(string username, string password) : base(username, password)
        {
            
        }
    }
}