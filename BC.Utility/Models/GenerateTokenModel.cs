using System.Security.Claims;

namespace BC.Utility.Models
{
    public class GenerateTokenModel
    {
        public GenerateTokenModel()
        {
            Identity = new ClaimsIdentity();
        }

        public ClaimsIdentity Identity { get; set; }

        public double ExpiresInSeconds { get; set; }

        public string Audience { get; set; }

        public string Issuer { get; set; }
    }
}
