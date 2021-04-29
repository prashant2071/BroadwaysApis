using BroadwaysApiInterface.Models;
using BroadwaysApiInterface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadwaysApiInterface.Implementation
{
    public class RegisterService:IRegisteredService
    {
        public readonly EfContext _context;
            public RegisterService(EfContext context)
        {
            _context = context;
        }
        public async Task RegisterAsync(ApplicationUser model)
        {

            await _context.ApplicationUser.AddAsync(model);
            _context.SaveChanges();
        }


        public async Task GetRegisteredUser()
        {
            await _context.ApplicationUser.ToListAsync();
            
        }

    }
}
