using BroadwaysApiInterface.CommonModel;
using BroadwaysApiInterface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BroadwaysApiInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthorization _auth;
        public TokenController(IAuthorization auth)
        {
            _auth = auth;
        }
        [HttpPost("GetToken")]
        public ActionResult GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role, "admin")
            };
            var jwtResult = _auth.GenerateTokens(user.UserName, claims, DateTime.Now);

            return Ok(new TokenResultant
            {
                UserName = user.UserName,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString,
                Role = null
            });



        }
    }
}
