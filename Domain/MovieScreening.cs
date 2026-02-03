using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain;

public class MovieScreening
{
    private DateTime dateAndTime;
    private double pricePerSeat;
    private Movie movie;
    private List<MovieTicket> movieTickets = new List<MovieTicket>();

    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        this.dateAndTime = dateAndTime;
        this.pricePerSeat = pricePerSeat;
        this.movie = movie;
        movie.AddScreening(this);
    }

    public double GetPricePerSeat()
    {
        return 1;
    }

    public override string ToString()
    {
        return $"Date and Time: {dateAndTime}, Price per seat: {pricePerSeat}";
    }
}
