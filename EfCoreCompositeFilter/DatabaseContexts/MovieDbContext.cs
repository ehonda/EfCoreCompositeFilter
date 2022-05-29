using Microsoft.EntityFrameworkCore;

namespace EfCoreCompositeFilter.DatabaseContexts;

public class MovieDbContext: DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie("Action Movie", "E.Honda"),
            new("Documentary", "Vega"),
            new("Thriller", "Guile"));
    }
}