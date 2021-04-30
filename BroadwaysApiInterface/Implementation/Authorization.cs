using BroadwaysApiInterface.CommonModel;
using BroadwaysApiInterface.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BroadwaysApiInterface.Implementation
{
    public class Authorization : IAuthorization
    {
        private readonly JwtToken _jwtTokenConfig;
        private readonly byte[] _secret;
        public Authorization(JwtToken jwtTokenConfig)
        {
            _jwtTokenConfig = jwtTokenConfig;
            _secret = Encoding.ASCII.GetBytes(jwtTokenConfig.Secret);
        }


        public AuthResultant GenerateTokens(string username, Claim[] claims, DateTime now)
        {

            var audienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);
            var jwtToken = new JwtSecurityToken( 
                _jwtTokenConfig.Issuer,
                audienceClaim ? _jwtTokenConfig.Audience : string.Empty,
                claims,
                expires: now.AddMinutes(_jwtTokenConfig.AccessTokenExpiration));
            //this JwtSecurityTokenHandler create the the token
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            var refreshToken = new RefreshToken
            {
                UserName = username,
                TokenString = GenerateRefreshToken(),
                ExpireAt = now.AddMinutes(_jwtTokenConfig.RefreshTokenExpiration)
            };
            return new AuthResultant
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };
        }
        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

   
    }
}
