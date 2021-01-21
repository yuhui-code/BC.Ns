﻿using BC.Ns.Domain.Interface;
using BC.Ns.Models.Request;
using BC.Ns.Models.Response;
using System.Threading.Tasks;
using System.Web.Http;

namespace BC.Ns.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IAccountDomain _accountDomain;

        public AccountController(IAccountDomain accountDomain)
        {
            _accountDomain = accountDomain;
        }

        /// <summary>
        /// login
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("login")]
        [AllowAnonymous]
        public async Task<AccountResponse> Login(string username, string password)
        {
            return await _accountDomain.Login(username, password);
        }
    }
}