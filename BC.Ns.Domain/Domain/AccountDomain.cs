using BC.Ns.Domain.Interface;
using BC.Ns.Models.Response;
using BC.Utility;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using BC.WebApi.Logger;
using BC.Ns.Data.EFCore;
using Microsoft.EntityFrameworkCore;

namespace BC.Ns.Domain.Domain
{
    public class AccountDomain : IAccountDomain
    {
        private readonly NsDbContext _dbContext;
        private readonly ILogger<AccountDomain> _logger;

        public AccountDomain(NsDbContext dbContext, ILogger<AccountDomain> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<AccountResponse> Login(string username, string password)
        {
            var userinfo = await _dbContext.Users.FirstOrDefaultAsync(c => c.UserName == username && !c.IsDelete);

            var identityClaims = new List<Claim>()
                {
                    new Claim("email",userinfo.Email)
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
