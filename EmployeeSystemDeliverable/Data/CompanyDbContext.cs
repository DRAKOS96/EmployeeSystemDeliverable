using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EmployeeSystemDeliverable.Data.Entities;
using EmployeeSystemDeliverable.BLL;

namespace EmployeeSystemDeliverable.Data
{
    public class CompanyDbContext : DbContext
    {

        public DbSet<Employee> Employee=> Set<Employee>();

        public DbSet<Skill> Skills { get; set; }


        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
         : base(options)
        { }
    }
}
