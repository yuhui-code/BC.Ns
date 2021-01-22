using BC.Utility.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BC.Utility
{
    public static class TokenHelper
    {
        private static string _secret = ConfigurationManager.AppSettings["tokenSecret"];
        private static string _expireMinutes = ConfigurationManager.AppSettings["tokenExpireMinutes"];
        private static string _issuer = ConfigurationManager.AppSettings["tokenIssuer"];
        private static string _audience = ConfigurationManager.AppSettings["tokenAudience"];
        
        /// <summary>
        /// generate token
        /// </summary>
        /// <param name="identityClaims">Here you can write something you want to put in the token</param>
        /// <returns></returns>
        public static TokenModel GenerateToken(IEnumerable<Claim> identityClaims)
        {
            var date = DateTimeOffset.UtcNow;
            var signDate = date.ToUnixTimeSeconds().ToString();
            var expiresDate = date.UtcDateTime.AddMinutes(int.Parse(_expireMinutes));

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, signDate, ClaimValueTypes.Integer64)
            };

            claims.AddRange(identityClaims);

            var tokenOptions = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: claims,
                    notBefore: date.UtcDateTime,
                    expires: expiresDate,
                    signingCredentials: signinCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenModel()
            {
                TokenType = "Bearer",
                AccessToken = token,
                ExpiresIn = expiresDate
            };
        }

        /// <summary>
        /// This method decodes the string token and returns the information object of the secret key
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                if (jwtToken == null) return null;

                // Generate the byte array corresponding to the encoding
                var symmetricKey = Encoding.UTF8.GetBytes(_secret);

                // Generate parameters for validation token
                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true, // token是否包含有效期
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    ValidateTokenReplay = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey) // 生成token时的安全秘钥
                };

                SecurityToken securityToken; // 接受解码后的token对象
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
                return principal; // 返回秘钥的主体对象，包含秘钥的所有相关信息
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
