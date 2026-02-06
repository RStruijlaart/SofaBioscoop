using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain;

public class Movie
{
    private string title;
    private List<MovieScreening> movieScreenings = new List<MovieScreening>();

    public Movie(string title)
    {
        this.title = title;
    }

    public void AddScreening(MovieScreening movieScreening)
    {
        this.movieScreenings.Add(movieScreening);
    }

    public override string ToString()
    {
        return $"Title: {title}";
    }
}
