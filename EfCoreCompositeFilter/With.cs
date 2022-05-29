using Microsoft.EntityFrameworkCore;

namespace EfCoreCompositeFilter;

public static class With
{
    public static void Database<TDbContext>(Action action)
        where TDbContext : DbContext, new()
    {
        Setup();
        action();
        Teardown();
        
        void Setup()
        {
            using var context = new TDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        void Teardown()
        {
            using var context = new TDbContext();
            context.Database.EnsureDeleted();
        }
    }
}
