using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Bank.Security
{
    public class SecurityRetriever : ISecurityRetriver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string GetCardNumber => _httpContextAccessor.HttpContext.User.FindFirst("User").Value;

        public SecurityRetriever(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogIn(string cardNumber)
        {
            var claims = new List<Claim>
            {
                new Claim("User", cardNumber),
            };

            await LoginInternal(claims);
        }

        public async Task PassIn(string cardNumber)
        {
            var oldClaim = _httpContextAccessor.HttpContext.User.FindFirst("User");

            var claims = new List<Claim>
            {
                new Claim("FullUser", cardNumber),
                oldClaim
            };

            await LoginInternal(claims);
        }

        private async Task LoginInternal(List<Claim> claims)
        {
            var identity = new ClaimsIdentity(claims, "CardCookie");

            await _httpContextAccessor.HttpContext.SignInAsync("CardCookie", new ClaimsPrincipal(identity));
        }

        public async Task LogOut() => await _httpContextAccessor.HttpContext.SignOutAsync();

    }
}
