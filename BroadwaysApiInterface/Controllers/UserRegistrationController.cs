using BroadwaysApiInterface.CommonModel;
using BroadwaysApiInterface.Models;
using BroadwaysApiInterface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BroadwaysApiInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IRegisteredService _context;
        private readonly IAuthorization _auth;
        public UserRegistrationController(IRegisteredService context,IAuthorization auth)
        {
            _context = context;
            _auth = auth;
        }

        [HttpPost("Register")]
        public Task Register(ApplicationUser model)
        {
            return _context.RegisterAsync(model);
        }
        [HttpPost]
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