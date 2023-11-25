using Data_NS2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data_NS2.Migrations
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> ContactEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"data source=d:\contacts.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>()
                .HasKey(e => e.ContactId);
            modelBuilder.Entity<ContactEntity>()
                .HasData(
                    new ContactEntity()
                    {
                        ContactId = 1,
                        Name = "Test",
                        Email = "test@emai.pl",
                        Phone = "123456789",
                        Priority = 1
                    },
                    new ContactEntity()
                    {
                        ContactId = 2,
                        Name = "Test2",
                        Email = "test2@emai.pl",
                        Phone = "987654321",
                        Priority = 3,
                        Birth = new DateTime(2000, 10, 10)
                    }
                );
        }
    }
}
