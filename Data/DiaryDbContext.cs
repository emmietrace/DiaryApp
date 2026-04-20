using System;
using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace DiaryApp.Data
{
    public class DiaryDbContext : DbContext
    {
        public DbSet<DiaryEntry> DiaryEntries { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PT9FSNK\SQLEXPRESS;Database=DiaryAppDb;Trusted_Connection=True;TrustServerCertificate=True;");

            optionsBuilder.LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }


    }
}
