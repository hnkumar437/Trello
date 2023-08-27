
using Microsoft.EntityFrameworkCore;
using Trello.Models;

namespace Trello.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; } // DbSet for tasks
        public DbSet<User> User { get; set; } // DbSet for user

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet properties for other entities as needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and other settings here
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
        }

    }
}
