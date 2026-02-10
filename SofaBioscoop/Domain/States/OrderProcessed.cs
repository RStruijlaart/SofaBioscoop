using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain.States
{
    public class OrderProcessed : OrderState
    {
        public string Cancel(Order order)
        {
            return "Your order has already been processed";
        }

        public string Pay(Order order)
        {
            return "Your order has already been processed";
        }

        public string Reminder(Order order)
        {
            return "Your order has already been processed";
        }

        public string Submit(Order order)
        {
            return "Your order has already been processed";
        }
    }
}
