using Domain.Entities;

namespace Domain.Interface
{
    public interface ICardRepository
    {
        Task<Card> GetCardByNumberAsync(string number);

        Task<Card> UpdateAsync(Card card);

        Task<double> GetBalanceByNumberAsync(string number);
    }
}
