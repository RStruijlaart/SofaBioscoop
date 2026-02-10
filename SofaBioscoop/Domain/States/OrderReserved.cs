using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain.States
{
    public class OrderReserved : OrderState
    {
        public string Cancel(Order order)
        {
            order.SetState(new OrderCanceled());
            return "The order has been canceled!";
        }

        public string Pay(Order order)
        {
            order.SetState(new OrderProcessed());
            return ("your payment is being processed");
        }

        public string Submit(Order order)
        {
            return "You already submitted!";
        }
    }
}
