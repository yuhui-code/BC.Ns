using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Utility.Models
{
    public class TokenModel
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
