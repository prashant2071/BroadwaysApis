using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BroadwaysApiInterface.Models;
using BroadwaysApiInterface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BroadwaysApiInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IRegisteredService _context;
        public UserRegistrationController(IRegisteredService context)
        {
            _context = context;
        }
        [HttpGet("Register")]
        public Task Register()
        {
            return _context.GetRegisteredUser();
        }
        [HttpPost("Register")]
        public Task Register(ApplicationUser model)
        {
            return _context.RegisterAsync(model);
        }
      

  
    }
}