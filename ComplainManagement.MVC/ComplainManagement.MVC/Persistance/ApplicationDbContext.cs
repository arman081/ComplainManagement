using ComplainManagement.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.MVC.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
        .HasIndex(u => u.UserEmail)
        .IsUnique();

            modelBuilder.Entity<User>()
        .HasIndex(u => u.UserName)
        .IsUnique();

            modelBuilder.Seed();
        }

        //entities
        public DbSet<User> Users { get; set; }
        public DbSet<ComplainType> ComplainTypes { get; set; }
        public DbSet<ComplainAndSolution> ComplainAndSolutions { get; set; }
        public DbSet<ComplainManagement.MVC.Models.ComplainEntryVm> ComplainEntryVm { get; set; }
    }
}
