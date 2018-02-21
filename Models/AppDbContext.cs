using Microsoft.EntityFrameworkCore;

namespace Palindrome.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PalinItem> PalinItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalinItem>()
                .Property(b => b.Text)
                .IsRequired();

            modelBuilder.Entity<PalinItem>()
                .Property(b => b.Hash)
                .IsRequired();
        }
    }
}