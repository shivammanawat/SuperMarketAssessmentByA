using System.Collections.Generic;
namespace SuperMarketAssessment
{
    public class Stock
    {
        IStockRepository _stockRepository;
        public Stock(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public IEnumerable<Product> CheckStockStatus(List<string> items)
        {
            return _stockRepository.CheckStockStatus(items);
        }
    }
}

