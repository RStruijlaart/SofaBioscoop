using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain.States
{
    public class OrderCanceled : OrderState
    {
        public string Cancel(Order order)
        {
            return "Your order has already been canceled"; 
        }

        public string Pay(Order order)
        {
            return "Your order has already been canceled";
        }

        public string Reminder(Order order)
        {
            return "Order has already been canceled";
        }

        public string Submit(Order order)
        {
            return "Your order has already been canceled";
        }
    }
}
