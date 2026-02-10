using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain.States
{
    public class OrderReserved : OrderState
    {
        public string cancel(Order order)
        {
            throw new NotImplementedException();
        }

        public string pay(Order order)
        {
            throw new NotImplementedException();
        }

        public string submit(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
