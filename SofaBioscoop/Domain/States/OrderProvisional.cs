using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain.States
{
    public class OrderProvisional : OrderState
    {
        public string Cancel(Order order)
        {
            order.SetState(new OrderCanceled());
            return "Your order has been canceled";
        }

        public string Pay(Order order)
        {
            order.SetState(new OrderProcessed());
            return "Your order has now been processed";
        }

        public string Reminder(Order order)
        {
            return "Order is already Provisional";
        }

        public string Submit(Order order)
        {
            return "Your order has already been submitted";
        }
    }
}
