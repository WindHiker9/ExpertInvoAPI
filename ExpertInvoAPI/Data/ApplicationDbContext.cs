using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ExpertInvoAPI.Models;
//I'm not sure if this page is necessary either
namespace ExpertInvoAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext (DbContextOptions <ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<EmployeesTb> EmployeesKey { get; set; }
        public DbSet<PlcTb> PlcKey { get; set; }
    }
}
