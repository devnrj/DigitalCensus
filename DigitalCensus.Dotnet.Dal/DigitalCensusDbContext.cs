using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalCensus.Dotnet.Dal.Entity;

namespace DigitalCensus.Dotnet.Dal
{
    public class DigitalCensusDbContext : DbContext
    {
        public DigitalCensusDbContext() : base("DigitalCensus")
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
    }
}
