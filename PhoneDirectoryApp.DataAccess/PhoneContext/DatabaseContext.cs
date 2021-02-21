using Microsoft.EntityFrameworkCore;
using PhoneDirectoryApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.DataAccess.PhoneContext
{
   public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=PhoneBookUserDB;Integrated Security=true; User Id=postgres;Password=123456;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User", "public");
            modelBuilder.Entity<ContactInfo>().ToTable("ContactInfo", "public");

        }
    }
}
