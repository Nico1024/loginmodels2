using System;
using Microsoft.EntityFrameworkCore;

namespace Loginnmodels2.Data
{
    public class dbcontext1 : DbContext
    {
        public DbSet<Pages> Paginas { get; set; }
        public DbSet<CaseMenu> Menu { get; set; }
        public DbSet<MenuPages> MenuElements { get; set; }
        public DbSet<Case>  Cases   { get; set; }
        public DbSet<User>  Users   { get; set; }
        public DbSet<UserHasCases> UserCaseRelation { get; set; }

        public dbcontext1(DbContextOptions<dbcontext1> options) : base(options)
        {
        }

       
    }
}
