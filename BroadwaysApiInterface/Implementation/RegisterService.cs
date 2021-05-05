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

        public void DeleteUserById(int id)
        {
            var user = _context.ApplicationUser.Find(id);
            _context.ApplicationUser.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<ApplicationUser> GetAllUser()
        {
            return _context.ApplicationUser.ToList();
        }

        public ApplicationUser GetUserById(int id)
        {
            return _context.ApplicationUser.Where(a => a.Id == id).FirstOrDefault();
        }

        public async Task RegisterAsync(ApplicationUser model)
        {

            await _context.ApplicationUser.AddAsync(model);
            _context.SaveChanges();

        }

        public void UpdateUserById(int id,ApplicationUser model)
        {
            var user=_context.ApplicationUser.Find(id);
            if (model.Username!=null) {
                user.Username = model.Username;
            }
            if (model.Password != null) 
            {
                user.Password = model.Password;
             }
            if(model.EntryDate != null)
            {
                user.EntryDate = model.EntryDate;
            }
            _context.SaveChanges();
        }
    }
}
