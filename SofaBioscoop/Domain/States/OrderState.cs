using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofaBioscoop.Domain.States
{
    public interface OrderState
    {
        public string Submit(Order order);
        public string Pay(Order order);
        public string Cancel(Order order);
    }
}
