using API_Labb3.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Labb3.Data
{
    public class PersonInterestDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }
        public DbSet<Link> Links { get; set; }

        public PersonInterestDbContext(DbContextOptions<PersonInterestDbContext> option) : base(option)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //connects pi with p.id and i.id with primary key so it cannot be dubletter
            //modelBuilder.Entity<PersonInterest>()
            //    .HasKey(pi => new { pi.PersonID, pi.InterestID });

            //for person connection
            //modelBuilder.Entity<PersonInterest>()
            //    .HasOne(pi => pi.Persons) //pi has one person
            //    .WithMany(p => p.PersonInterests) //p has mnay personintrest
            //    .HasForeignKey(pi => pi.PersonID); //and pi only has one foreign personID

            //for intrest connection 
            //modelBuilder.Entity<PersonInterest>()
            //   .HasOne(pi => pi.Interests) //pi has one intrest
            //   .WithMany(i => i.PersonInterests) //p has mnay personintrest
            //   .HasForeignKey(pi => pi.InterestID); //and pi only has one foreign intrestID

            ////for link connection
            //modelBuilder.Entity<Link>()
            //    .HasOne(l => l.PersonInterests)
            //    .WithMany(pi => pi.Links)
            //    .HasForeignKey(l => l.Id); //fk from personInterest to link so it will not have a dubbeldata 

            SeedData(modelBuilder);
        }

        protected void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasData(
                new Person { Id = 1, Firstname = "Fibie", Lastname = "MeowMoew", Age = 16 },
                new Person { Id = 2, Firstname = "Herman", Lastname = "Axelsson", Age = 27 },
                new Person { Id = 3, Firstname = "Nalle", Lastname = "Pugh", Age = 78 },
                new Person { Id = 4, Firstname = "Holly", Lastname = "WoofWoof", Age = 10 },
                new Person { Id = 5, Firstname = "Rosa", Lastname = "FierceKitty", Age = 17 }
                );

            modelBuilder.Entity<Interest>()
                .HasData(
                new Interest { Id = 1, Title = "Volleyball" },
                new Interest { Id = 2, Title = "Photograph", Description = "Taking pictures with either an old or a new camera" },
                new Interest { Id = 3, Title = "Gaming", Description = "Both computer and video games" },
                new Interest { Id = 4, Title = "Chess", Description = "Back and white peices" },
                new Interest { Id = 5, Title = "Programming", Description = "All kind of programming" },
                new Interest { Id = 6, Title = "Painting", Description = "Specificly with oilpaint" },
                new Interest { Id = 7, Title = "Climing", Description = "Outside climbing on big and steep mountains" },
                new Interest { Id = 8, Title = "Hiking", Description = "Somewhere, anywhere" }
                );


            modelBuilder.Entity<PersonInterest>().HasData(
                new PersonInterest { Id = 1, PersonID = 1, InterestID = 8},
                new PersonInterest { Id = 2, PersonID = 1, InterestID = 3},
                new PersonInterest { Id = 3, PersonID = 1, InterestID = 5},
                new PersonInterest { Id = 4, PersonID = 2, InterestID = 8},
                new PersonInterest { Id = 5, PersonID = 2, InterestID = 1 },
                new PersonInterest { Id = 6, PersonID = 3, InterestID = 3 },
                new PersonInterest { Id = 7, PersonID = 4, InterestID = 2 },
                new PersonInterest { Id = 8, PersonID = 3, InterestID = 4 },
                new PersonInterest { Id = 9, PersonID = 5, InterestID = 6 },
                new PersonInterest { Id = 10, PersonID = 5, InterestID = 7 }
                );


            modelBuilder.Entity<Link>()
                .HasData(
                new Link { Id = 1, URL = "www.google.se", PersonInterestId = 2 },
                new Link { Id = 2, URL = "www.medium.com", PersonInterestId = 4 },
                new Link { Id = 3, URL = "www.youtube.com", PersonInterestId = 2 },
                new Link { Id = 4, URL = "www.trail.com", PersonInterestId = 1},
                new Link { Id = 5, URL = "www.chess.com", PersonInterestId = 3 },
                new Link { Id = 6, URL = "www.spela.com", PersonInterestId = 5 },
                new Link { Id = 7, URL = "www.blocket.com", PersonInterestId = 1 },
                new Link { Id = 8, URL = "www.aftonbladet.se", PersonInterestId = 3 }

                );
        }
    }
}
