using Microsoft.EntityFrameworkCore;

namespace EfCoreCompositeFilter.DatabaseContexts;

public class MovieDbContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie("Action Movie", "E.Honda") { Id = 1 },
            new("Documentary", "Vega") { Id = 2 },
            new("Thriller", "Guile") { Id = 3 });
    }
}