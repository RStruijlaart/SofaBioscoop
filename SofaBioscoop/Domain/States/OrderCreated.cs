using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain.States
{

    public class OrderCreated : OrderState
    {
        public string Cancel(Order order)
        {
            return "The order cannot be canceled in the current state!";
        }

        public string Pay(Order order)
        {
            return "You have not chosen your seats yet. Payment is restricted!";
        }

        public string Submit(Order order)
        {
            order.SetState(new OrderReserved());
            return "Your order has been submitted!";
        }
    }
}
