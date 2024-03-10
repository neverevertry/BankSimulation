namespace Bank.Security
{
    public interface ISecurityRetriver
    {
        Task LogIn(string cardNumber);
        string GetCardNumber { get; }
        Task LogOut();
        Task PassIn(string cardNumber);
    }
}
