using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain;

public class MovieScreening
{
    private DateTime dateAndTime;
    private double pricePerSeat;

    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        this.dateAndTime = dateAndTime;
        this.pricePerSeat = pricePerSeat;
        movie.addScreening(this);
    }

    public double getPricePerSeat()
    {
        return 1;
    }

    public override string ToString()
    {
        return $"Date and Time: {dateAndTime}, Price per seat: {pricePerSeat}";
    }
}
