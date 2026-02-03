using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain;

public class Movie
{
    private string title;

    public Movie(string title)
    {
        this.title = title;
    }

    public void addScreening(MovieScreening movieScreening)
    {
        
    }

    public override string ToString()
    {
        return $"Title: {title}";
    }
}
