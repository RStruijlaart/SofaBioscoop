using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain.States
{
    public interface OrderState
    {
        public string submit(Order order);
        public string pay(Order order);
        public string cancel(Order order);
    }
}
