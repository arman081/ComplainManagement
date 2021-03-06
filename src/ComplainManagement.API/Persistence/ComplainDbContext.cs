using ComplainManagement.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.API.Persistence
{
    public class ComplainDbContext : DbContext
    {

        public ComplainDbContext(DbContextOptions<ComplainDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComplainManagementUser>()
        .HasIndex(u => u.UserEmail)
        .IsUnique();

            modelBuilder.Entity<ComplainManagementUser>()
        .HasIndex(u => u.UserName)
        .IsUnique();

            modelBuilder.Seed();
        }

        //entities
        public DbSet<ComplainManagementUser> ComplainManagementUsers { get; set; }
        public DbSet<ComplainType> ComplainTypes { get; set; }
        public DbSet<ComplainAndSolution> ComplainAndSolutions { get; set; }
    }
}
