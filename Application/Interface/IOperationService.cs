using Domain.Entities;

namespace Application.Interface
{
    public interface IOperationService
    {
        Task BalanceAsync(int cardId);

        Task WithdrawMoneyAsync(int cardId, double sum);

        Task AddMoneyAsync (int cardId, double sum);
    }
}
