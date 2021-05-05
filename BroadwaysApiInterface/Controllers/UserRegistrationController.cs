using BroadwaysApiInterface.CommonModel;
using BroadwaysApiInterface.Models;
using BroadwaysApiInterface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BroadwaysApiInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IRegisteredService _context;
        private readonly IAuthorization _auth;
        public UserRegistrationController(IRegisteredService context, IAuthorization auth)
        {
            _context = context;
            _auth = auth;
        }

        [HttpGet("Register")]
        public ActionResult<IEnumerable<ApplicationUser>> Get()
        {
            return Ok(_context.GetAllUser());
        }
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<ApplicationUser> GetById(int id)
        {
            var result = _context.GetUserById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }
        [HttpPost("Register")]
        public Task Register(ApplicationUser model)
        {
            return _context.RegisterAsync(model);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUserById(int id, ApplicationUser model)
        {
            _context.UpdateUserById(id, model);
            return Ok("user updated successfully");

        }
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteUserById(int id)
        {
            _context.DeleteUserById(id);
            return Ok("User Deleted Successfully");
        }



    }
}