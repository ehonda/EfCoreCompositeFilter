using Microsoft.EntityFrameworkCore;

namespace EfCoreCompositeFilter.DatabaseContexts;

public class MariaDbMovieDbContext : MovieDbContext
{
    private const string ConnectionString = "server=localhost;user=root;" +
                                             "password=movies-root-password;database=movies-db";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            ConnectionString,
            ServerVersion.AutoDetect(ConnectionString));
    }
}
