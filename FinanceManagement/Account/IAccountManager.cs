namespace FinanceManagement.Account
{
    public interface IAccountManager
    {
        bool CreateAccount(string username, string password);
        bool Login(string username, string password);

    }
}