using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    class Order
    {
        public Good Good;
        public int Count;

        public int GetTotalPrice()
        {
            return Good.Price * Count;
        }
        
        public void Apply()
        {
            Good.Count -= Count;
        }
    }
}
