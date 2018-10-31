using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ExpertInvoAPI.Models;

namespace ExpertInvoAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext (DbContextOptions <ApplicationDbContext> options) : base(options)
        {
            
        }
        public ApplicationDbContext() { }

        public DbSet<EmployeeModel> EmployeeModel { get; set; }
        public DbSet<PlcModel> PlcModel { get; set; }
    }
}
