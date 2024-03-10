using Application.Interface;
using Bank.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [Authorize(Policy = "PartiallyAuthorized")]
    public class CardController : Controller
    {
        private readonly ICardService _cardService;

        private readonly ISecurityRetriver _securityRetriver;

        public CardController(ICardService cardServices, ISecurityRetriver securityRetriver)
        {
            _cardService = cardServices;
            _securityRetriver = securityRetriver;
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(long number)
        {
            var result = await _cardService.GetCardByNumberAsync(number);

            _securityRetriver.LogIn(result.number);

            return View("Password");
        }

        public ViewResult Password()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Password(int password)
        {
            var cardNumber = _securityRetriver.GetCardNumber;
            
            var res = await _cardService.AccessByPasswordAsync(cardNumber, password);

            return RedirectToAction("Menu", "CardMenu");
        }
    }
}
