using Microsoft.EntityFrameworkCore;
using PhoneDirectoryApp.ReportData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.ReportData.ReportContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=PhoneBookReportDB;Integrated Security=true; User Id=postgres;Password=123456;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>().ToTable("Report", "public");


        }
    }
}
