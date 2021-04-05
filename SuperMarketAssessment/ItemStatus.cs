using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssessment
{

    public class ItemStatus : IItemStatus
    {
        
      
        public bool productInStock(Random randomNumbers)
        {
            return randomNumbers.Next(0, 10) % 3 != 0;
        }
    }

}
