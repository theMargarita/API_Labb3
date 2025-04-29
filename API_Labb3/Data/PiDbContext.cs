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

            SeedData(modelBuilder);
        }

        protected void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasData(
                new Person { Id = 1, Firstname = "Fibie", Lastname = "MeowMoew", Age = 16 },
                new Person { Id = 2, Firstname = "Herman", Lastname = "Axelsson", Age = 27 },
                new Person { Id = 3, Firstname = "Bob", Lastname = "Bobsson", Age = 78 },
                new Person { Id = 4, Firstname = "Holly", Lastname = "WoofWoof", Age = 10 },
                new Person { Id = 5, Firstname = "Rosa", Lastname = "FierceKitty", Age = 17 }
                );

            modelBuilder.Entity<Intrest>()
                .HasData(
                new Intrest { Id = 1, Title = "Volleyball"},
                new Intrest { Id = 2, Title = "Photograph", Description = "Taking pictures with either an old or a new camera"},
                new Intrest { Id = 3, Title = "Gaming", Description = "Both computer and vidio games"},
                new Intrest { Id = 4, Title = "Chess", Description = "Back and white peices"},
                new Intrest { Id = 5, Title = "Programming", Description = "All kind of programming"},
                new Intrest { Id = 6, Title = "Painting", Description = "Specificly with oilpaint"},
                new Intrest { Id = 7, Title = "Climing", Description = "Outside climbing on big and steep mountains"},
                new Intrest { Id = 8, Title = "Hiking", Description = "Somewhere, anywhere"}
                );


        }
    }
}
