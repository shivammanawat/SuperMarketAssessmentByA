using SuperMarketAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace SuperMarketAssessment
{
    public class ShoppingService : IShoppingService
    {
        private readonly int customerId;
        private double OrderValue = 0;
        private IStockRepository _stockRepository;
        private IDiscountService _discountService;
        private IPaymentGateway _paymentGateWay;
        private ILogger _logger;
        public ShoppingService(int customerId, IStockRepository stockRepository, IDiscountService discountService, IPaymentGateway paymentGateWay, ILogger logger)
        {
            this.customerId = customerId;
            _stockRepository = stockRepository;
            _discountService = discountService;
            _logger = logger;
            _paymentGateWay = paymentGateWay;
        }
        public int BuyItems(List<string> items)
        {
            var products = _stockRepository.CheckStockStatus(items);
            double price = 0;
            foreach (var item in products)
            {
                price += item.Price;
            }
            OrderValue = _discountService.ApplyDiscount(price);

            var requestUri = "http://www.google.com/search?q=" + OrderValue;
            var result = _paymentGateWay.GetAsync(requestUri).Result; //pseudo payment gateway call
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Payment processed successfully");
            }
            else
            {
                LogPaymentFailure(result);
            }
            return products.Count();
        }

        private void LogPaymentFailure(HttpResponseMessage result)
        {
            switch (result.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    throw new ArgumentException("Invalid customer : " + customerId);
                default:
                    _logger.write("Error in processing payment " + customerId);
                    break;
            }
        }



    }


}