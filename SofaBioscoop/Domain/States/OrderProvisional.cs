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
            throw new NotImplementedException();
        }

        public string Pay(Order order)
        {
            throw new NotImplementedException();
        }

        public string Submit(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
