using Microsoft.EntityFrameworkCore;

namespace EfCoreCompositeFilter;

public class MovieDbContext: DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=movies.db");
    }
}