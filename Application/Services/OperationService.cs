using Application.Interface;
using Domain.Entities;
using Domain.Interface;

namespace Application.Services
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;

        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public async Task BalanceAsync(int cardId)
        {
            var newOperation = new Operation
            {
                cardId = cardId,
                descriptionId = 1,
                data = DateTime.Now
            };

            await _operationRepository.AddAsync(newOperation);
        }

        public async Task WithdrawMoneyAsync(int cardId, double sum)
        {
            var newOperation = new Operation
            {
                cardId = cardId,
                descriptionId = 2,
                sum = sum,
                data = DateTime.Now
            };

            await _operationRepository.AddAsync(newOperation);
        }

        public async Task AddMoneyAsync(int cardId, double sum)
        {
            var newOperation = new Operation
            {
                cardId = cardId,
                descriptionId = 3,
                sum = sum,
                data = DateTime.Now
            }; ;

            await _operationRepository.AddAsync(newOperation);
        }
    }
}
