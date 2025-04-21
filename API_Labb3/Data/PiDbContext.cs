using API_Labb3.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Labb3.Data
{
    public class PiDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet <Interest> Interests { get; set; }
        public DbSet <PersonIntereset> Personinterests { get; set; }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
