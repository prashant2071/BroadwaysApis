using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadwaysApiInterface.Models
{
    public class EfContext : DbContext
    {
        public DbSet<Country> Country { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {

        }
    
       


    }
}
