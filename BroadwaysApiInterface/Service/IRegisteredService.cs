using BroadwaysApiInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadwaysApiInterface.Service
{
    public interface IRegisteredService
    {
        Task RegisterAsync(ApplicationUser model);
         IEnumerable<ApplicationUser> GetAllUser();
        ApplicationUser GetUserById(int id);
        void UpdateUserById(int id,ApplicationUser model);
        void DeleteUserById(int id);

        

    }
}
