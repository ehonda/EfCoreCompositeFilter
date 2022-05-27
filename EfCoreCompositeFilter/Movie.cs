using JetBrains.Annotations;

namespace EfCoreCompositeFilter;

[PublicAPI]
public class Movie
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Director { get; set; }

    public Movie(string title, string director) => (Title, Director) = (title, director);
}