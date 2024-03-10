using Domain.Entities;

namespace Application.Interface
{
    public interface ICardService
    {
        Task<Card> GetCardByNumberAsync(string number);

        Task<Card> AccessByPasswordAsync(string number, int password);

        Task<double> BalanceAsync(string number);

        Task<Card> WithdrawMoneyAsync(string number, double sum);

        Task<Card> AddMoneyAsync(string number, double sum);
    }
}
