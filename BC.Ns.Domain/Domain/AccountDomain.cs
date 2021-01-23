using BC.Ns.Domain.Interface;
using BC.Ns.Models.Request;
using BC.Ns.Models.Response;
using BC.Utility;
using BC.Utility.Models;
using BC.Jwt.Logger;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using BC.Ns.Data;

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
            using (var context = new NsDbContext())
            {
                var userinfo = context.Users.FindAsync(1).Result;

                var identityClaims = new List<Claim>()
                {
                    new Claim("useroid",username)
                };

                var token = TokenHelper.GenerateToken(identityClaims);

                var result = new AccountResponse
                {
                    TokenType = token.TokenType,
                    AccessToken = token.AccessToken,
                    ExpiresIn = token.ExpiresIn
                };

                return await Task.FromResult(result);
            }
        }
    }
}
