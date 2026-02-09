using SofaBioscoop.Domain;
using SofaBioscoop.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Interfaces
{
    public interface OrderPricingBehaviour
    {
        public double CalculatePrice(IEnumerable<MovieTicket> tickets);
    }
}
