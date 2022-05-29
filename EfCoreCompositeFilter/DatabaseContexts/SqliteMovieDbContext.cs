using Microsoft.EntityFrameworkCore;

namespace EfCoreCompositeFilter.DatabaseContexts;

public class SqliteMovieDbContext : MovieDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite("DataSource=movies.db");
    }
}
