using BroadwaysApiInterface.Models;
using BroadwaysApiInterface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadwaysApiInterface.Implementation
{
    public class UserService:IUserService
    {
        private readonly EfContext _context;

        private UserService(EfContext context)
        {
            _context = context;
        }
    }
}
