using Application.Interface;
using Bank.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [Authorize(Policy = "Fulluser")]
    [Route("/CardMenu")]
    public class CardMenuController : Controller
    {
        private readonly ICardService _cardService;

        private readonly IOperationService _operationService;

        private readonly ISecurityRetriver _securityRetriver;

        public CardMenuController(ICardService cardServices, IOperationService operationService, ISecurityRetriver securityRetriver)
        {
            _cardService = cardServices;
            _operationService = operationService;
            _securityRetriver = securityRetriver;
        }

        public ViewResult Menu()
        {
            return View();
        }

        [HttpGet("/Balance")]
        public async Task<IActionResult> Balance()
        {
            var cardNumber = _securityRetriver.GetCardNumber;

            var result = await _cardService.BalanceAsync(cardNumber);

            var card = await _cardService.GetCardByNumberAsync(cardNumber);

            await _operationService.BalanceAsync(card.id);

            return View("Balance", card);
        }

        [HttpPost("/Withdraw")]
        public async Task<IActionResult> WithdrawMoney(double sum)
        {
            var cardNumber = _securityRetriver.GetCardNumber;

            var result = await _cardService.WithdrawMoneyAsync(cardNumber, sum);

            await _operationService.WithdrawMoneyAsync(result.id, sum);

            return View("Balance");
        }

        [HttpPost ("/Add")]
        public async Task<IActionResult> AddMoney(double sum)
        {
            var cardNumber = _securityRetriver.GetCardNumber;

            var result = await _cardService.AddMoneyAsync(cardNumber, sum);

            await _operationService.WithdrawMoneyAsync(result.id, sum);

            return View();
        }
    }
}
