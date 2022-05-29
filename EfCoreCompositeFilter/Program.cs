using System.Collections.Immutable;
using EfCoreCompositeFilter;
using EfCoreCompositeFilter.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

SetupDatabase();

InsertData();

var data = RetrieveData();
PrintData(data);

TeardownDatabase();

void SetupDatabase()
{
    using var context = new MovieDbContext();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

void InsertData()
{
    using var context = new MovieDbContext();
    context.Movies.Add(new("Action Movie", "E.Honda"));
    context.Movies.Add(new("Documentary", "Vega"));
    context.Movies.Add(new("Thriller", "Guile"));
    context.SaveChanges();
}

ImmutableArray<Movie> RetrieveData()
{
    using var context = new MovieDbContext();
    return context.Movies
        .FromSqlInterpolated(@$"
SELECT *
FROM Movies m
WHERE (m.Title, m.Director)
IN (VALUES ('Action Movie', 'E.Honda'), ('Thriller', 'Guile'))
")
        .ToImmutableArray();
}

void PrintData(IEnumerable<Movie> movies)
{
    foreach (var movie in movies)
    {
        Console.WriteLine($"{movie.Title} - {movie.Director}");
    }
}

void TeardownDatabase()
{
    using var context = new MovieDbContext();
    context.Database.EnsureDeleted();
}