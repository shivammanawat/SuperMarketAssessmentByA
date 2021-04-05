using SuperMarketAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssessment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please Enter your customer id");
            int customerId = Int32.Parse(Console.ReadLine());
            var stockRepository = new StockRepository(new ItemStatus());
            var discountService = new DiscountService(new platinumCustomer(1234,10));
            var paymentGateWay = new PaymentGateway(new HttpClient());
            var logger = new Logger();
            List<string> items = new List<string>()
            {
                "Breads",
                "Milk",
                "Cheese",
                "Butter",
                "Biscuits",
                "Dryfruits"
            };
            ShoppingService shopping = new ShoppingService(customerId,stockRepository,discountService,paymentGateWay,logger);
            var count = shopping.BuyItems(items);
            Console.WriteLine($"Shopping done for {count} products ");
        }

        public static CustomerFactory GetCustomerFactory(int customerId)
        {
            int[] platinaumCustomers = new int[] { 1010, 2020, 3030, 4040 };
            int[] goldCustomers = new int[] { 1234, 5678, 9876 };
            int[] silverCustomers = new int[] { 1111, 2222, 9999 };
            double platinaumDiscountPercent = 50;
            double goldDiscountPercent = 30;
            double silverDiscountPercent = 10;
            double defaultDiscountPercent = 0;

            CustomerFactory factory;
            if (platinaumCustomers.Contains(customerId))
            {
                factory = new PlatinumCustomerFactory(customerId, platinaumDiscountPercent);
            }
            else if (goldCustomers.Contains(customerId))
            {
                factory = new GoldCustomerFactory(customerId, goldDiscountPercent);
            }
            else if (silverCustomers.Contains(customerId))
            {
                factory = new SilverCustomerFactory(customerId, silverDiscountPercent);
            }
            else
            {
                factory = new DefaultCustomerFactory(customerId, defaultDiscountPercent);
            }

            return factory;
        }
    }
}
