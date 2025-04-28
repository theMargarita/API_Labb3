using API_Labb3.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Labb3.Data
{
    public class PiDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet <Intrest> Interests { get; set; }
        public DbSet <PersonIntreset> Personintrests { get; set; }
        public DbSet <Link> Links{ get; set; }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //connects pi with p.id and i.id with primary key so it cannot be dubletter
            modelBuilder.Entity<PersonIntreset>()
                .HasKey(pi => new { pi.PersonID, pi.InterestID });

            //for person connection
            modelBuilder.Entity<PersonIntreset>()
                .HasOne(pi => pi.Persons) //pi has one person
                .WithMany(p => p.PersonIntrests) //p has mnay personintrest
                .HasForeignKey(pi => pi.PersonID); //and pi only has one foreign personID

            //for intrest connection 
            modelBuilder.Entity<PersonIntreset>()
               .HasOne(pi => pi.Intrests) //pi has one intrest
               .WithMany(i => i.PersonIntrests) //p has mnay personintrest
               .HasForeignKey(pi => pi.InterestID); //and pi only has one foreign intrestID

            //for link connection
            modelBuilder.Entity<Link>()
                .HasOne(l => l.PersonIntrests)
                .WithMany(pi => pi.Links)
                .HasForeignKey(l => new { l.PerInt_ID, l.IntPer_ID }); //combine id to match the correct primary key 



            //modelBuilder.Entity<PersonIntreset>()
            //    .HasMany(p => p.Persons)
            //    .WithMany(i => i.Pers)
            //    .UsingEntity(pi => pi.HasData(
            //        ));


        }

    }
}
