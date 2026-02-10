using SofaBioscoop.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SofaBioscoop.Domain.Order
{
    public class OrderPricingBehaviourRegular : OrderPricingBehaviour
    {
        public double CalculatePrice(IEnumerable<MovieTicket> tickets)
        {
            double price = 0;

            if (tickets is null)
            {
                return 0; 
            }
            DateTime dateTime = tickets.First()
                    .GetMovieScreening()
                    .GetDateTime();
            bool weekend = dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;

            int counter = 1;
            foreach (MovieTicket ticket in tickets)
            {
                if (counter % 2 == 0 && !weekend)
                {
                    counter++;
                    continue;
                }
                price += ticket.GetPrice();
                counter++;
            }

            if (tickets.Count() >= 6 && weekend)
            {
                price = price * 0.9;
            }

            return price;
        }
    }
}
