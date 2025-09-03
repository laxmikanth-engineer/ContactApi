using ContactAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ContactAPI.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<Contact>().HasKey(x => x.Id);

            // Inserting record in seed data
            modelBuilder.Entity<Contact>().HasData(
               new Contact
               {
                   Id = 1,
                   FirstName = "Laxmi Kanth",
                   LastName = "Munagala",
                   Email = "laxmikanth.rao@gmail.com",
                   Phone = "8074109898",
                   IsActive = true
               }
           );
        }
    }
}
