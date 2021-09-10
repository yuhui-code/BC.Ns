using System;

namespace BC.Ns.Models.Response
{
    public class AccountResponse
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
