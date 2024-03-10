using Application.Interface;
using Domain.Entities;
using Domain.Interface;

namespace Application.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        private int blockCard = 1;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Card> GetCardByNumberAsync(string number)
        {
            var res = await _cardRepository.GetCardByNumberAsync(number);

            if (res != null)
            {
                if (!res.blocking)
                {
                    return res;
                }

                throw new Exception("Access to the card is blocked");
            }

            throw new Exception("Card is not found");
        }

        public async Task<Card> AccessByPasswordAsync(string number, int password)
        {
            var res = await _cardRepository.GetCardByNumberAsync(number);

            if (res.password == password)
            {
                return res;
            }

            else
            {
                blockCard++;

                if(blockCard == 4)
                {
                    res.blocking = true;

                    await _cardRepository.UpdateAsync(res);

                    throw new Exception("Card is blocked");
                }

                throw new Exception("Incorrect password, try again");
            }
        }

        public async Task<double> BalanceAsync(string number)
        {
            return await _cardRepository.GetBalanceByNumberAsync(number);
        }

        public async Task<Card> WithdrawMoneyAsync(string number, double sum)
        {
            var card = await _cardRepository.GetCardByNumberAsync(number);

            if(card.balance >= sum)
            {
                card.balance -= sum;

                await _cardRepository.UpdateAsync(card);

                return card;
            }

            throw new Exception("Limit exceeded");
        }

        public async Task<Card> AddMoneyAsync(string number, double sum)
        {
            if (sum > 0)
            {
                var card = await _cardRepository.GetCardByNumberAsync(number);

                card.balance += sum;

                await _cardRepository.UpdateAsync(card);

                return card;
            }

            throw new Exception("The amount cannot be less than or equal to zero");
        }
    }
}
