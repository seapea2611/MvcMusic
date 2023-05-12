using Microsoft.EntityFrameworkCore;

namespace MvcMusic.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Music> Musics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings, relationships, and constraints here
            // For example:
            // modelBuilder.Entity<Music>()
            //     .Property(m => m.Title)
            //     .HasMaxLength(100)
            //     .IsRequired();
        }
    }
}
