using System.Collections.Immutable;
using EfCoreCompositeFilter;
using EfCoreCompositeFilter.DatabaseContexts;
using EfCoreCompositeFilter.DatabaseContexts.Extensions;
using Microsoft.EntityFrameworkCore;

With.Database<SqliteMovieDbContext>(() =>
{
    var data = RetrieveData<SqliteMovieDbContext>();
    PrintData(data);
});

// With.Database<MariaDbMovieDbContext>(() =>
// {
//     var data = RetrieveData<MariaDbMovieDbContext>();
//     PrintData(data);
// });

ImmutableArray<Movie> RetrieveData<TDbContext>()
    where TDbContext : MovieDbContext, new()
{
    using var context = new TDbContext();
//     return context.Movies
//         .FromSqlInterpolated(@$"
// SELECT *
// FROM Movies m
// WHERE (m.Title, m.Director)
// IN (VALUES ('Action Movie', 'E.Honda'), ('Thriller', 'Guile'))
// ")
    return context.Movies
        .CompositeFilter(
            nameof(MovieDbContext.Movies),
            nameof(Movie.Title),
            nameof(Movie.Director),
            ("'Thriller'", "'Guile'"))
        .ToImmutableArray();
}

void PrintData(IEnumerable<Movie> movies)
{
    foreach (var movie in movies)
    {
        Console.WriteLine($"{movie.Title} - {movie.Director}");
    }
}
