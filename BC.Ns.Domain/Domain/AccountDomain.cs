using BC.Ns.Domain.Interface;
using BC.Ns.Models.Request;
using BC.Ns.Models.Response;
using BC.Utility;
using BC.Utility.Models;
using BC.Jwt.Logger;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BC.Ns.Domain.Domain
{
    public class AccountDomain : IAccountDomain
    {
        private ILogger<AccountDomain> _logger;

        public AccountDomain(ILogger<AccountDomain> logger)
        {
            _logger = logger;
        }

        public async Task<AccountResponse> Login(string username, string password)
        {
            var token = TokenHelper.GenerateToken(username);

            var result = new AccountResponse
            {
                TokenType = "Bearer",
                AccessToken = token,
                ExpiresIn = 1
            };

            return await Task.FromResult(result);
        }
    }
}
