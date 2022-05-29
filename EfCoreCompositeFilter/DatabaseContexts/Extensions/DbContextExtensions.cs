using Microsoft.EntityFrameworkCore;

namespace EfCoreCompositeFilter.DatabaseContexts.Extensions;

public static class DbContextExtensions
{
    public static IQueryable<TEntity> CompositeFilter<TEntity, T0, T1>(
        this DbSet<TEntity> entities,
        string tableName,
        string property0,
        string property1,
        params (T0, T1)[] filterValues)
        where TEntity : class
        where T0 : notnull
        where T1 : notnull
    {
        var filterValuesStrings = filterValues
            .Select(pair => $"({pair.Item1}, {pair.Item2})");
     
        // TODO: Use FromSqlInterpolated!
        var statement = $@"
SELECT *
FROM {tableName} t
WHERE (t.{property0}, t.{property1})
IN (VALUES {string.Join(", ", filterValuesStrings)})
";
        
        return entities.FromSqlRaw(statement);
    }
}
