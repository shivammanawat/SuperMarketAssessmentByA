using System;
using System.Collections.Generic;

namespace SuperMarketAssessment
{ 
    public class StockRepository : IStockRepository
    {
        IItemStatus _itemStatus;
        public StockRepository(IItemStatus itemStatus)
        {
            _itemStatus = itemStatus;
        }

        public IEnumerable<Product> CheckStockStatus(List<string> items)
        {
            Random randomNumbers = new Random();
            List<Product> products = new List<Product>();
            for (int i = 0; i < items.Count; i++)
            {
                Product product = new Product();
                product.Name = items[i];
                product.Price = randomNumbers.Next(100, 1000); //pseudo logic to assign random price

                if (_itemStatus.productInStock(randomNumbers)) //some pseudo logic to recreate in-stock / out-of-stock scenario
                { 
                    products.Add(product);
                }
            }
            return products;
        }
    }
}