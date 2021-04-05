using System.Collections.Generic;

namespace SuperMarketAssessment
{
    public interface IStockRepository
    {
        IEnumerable<Product> CheckStockStatus(List<string> items);
    
    }
}