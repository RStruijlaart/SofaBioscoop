using SofaBioscoop.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain.Order
{
    public class OrderPricingBehaviourStudent : OrderPricingBehaviour
    {
        public double CalculatePrice(IEnumerable<MovieTicket> tickets)
        {
            double price = 0;

            int counter = 1;
            foreach (MovieTicket ticket in tickets)
            {
                if (counter % 2 == 0)
                {
                    counter++;
                    continue;
                }

                if (ticket.IsPremiumTicket())
                {
                    price += ticket.GetPrice() - 1;
                }
                else
                {
                    price += ticket.GetPrice();
                }
                counter++;
            }

            if (tickets.Count() >= 6)
            {
                price = price * 0.9;
            }

            return price;
        }
    }
}
