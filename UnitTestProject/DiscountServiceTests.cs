using NUnit.Framework;
using SuperMarketAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestFixture]
    public class DiscountServiceTests
    {
        [Test]
        [TestCase(1010,200,100)]
        [TestCase(2020, 200, 100)]
        [TestCase(3030, 200, 100)]
        [TestCase(4040, 200, 100)]
        [TestCase(1010,0,0)]
        [TestCase(2020, 0, 0)]
        [TestCase(3030, 0, 0)]
        [TestCase(4040, 0, 0)]
        [TestCase(1010,-1000,-500)]
        [TestCase(2020, -1000, -500)]
        [TestCase(3030, -1000, -500)]
        [TestCase(4040, -1000, -500)]
            
        public void ApplyDiscountForPlatinumCustomer_ReturnDiscountedPrice(int customerId, double amount, double expectedDiscount)
        {
            double platinaumDiscountPercent = 50;
            ICustomer customer = new platinumCustomer(customerId, platinaumDiscountPercent);
            DiscountService discountService = new DiscountService(customer);
            var result = discountService.ApplyDiscount(amount);
            Assert.AreEqual(result, expectedDiscount);
        }

        [Test]
        [TestCase(1234,100,70)]
        [TestCase(5678,100,70)]
        [TestCase(9876,100,70)]
        [TestCase(1234, 0, 0)]
        [TestCase(5678, 0, 0)]
        [TestCase(9876, 0, 0)]
        [TestCase(1234, -100, -70)]
        [TestCase(5678, -100, -70)]
        [TestCase(9876, -100, -70)]
        public void ApplyDiscountForGoldCustomer_ReturnDiscountedPrice(int customerId, double amount, double expectedDiscount)
        {
            double goldDiscountPercent = 30;
            ICustomer customer = new GoldCustomer(customerId, goldDiscountPercent);
            DiscountService discountService = new DiscountService(customer);
            var result = discountService.ApplyDiscount(amount);
            Assert.AreEqual(result,expectedDiscount);
        }

        [Test]
        [TestCase(1111, 100, 90)]
        [TestCase(2222, 100, 90)]
        [TestCase(9999, 100, 90)]
        [TestCase(1111, 0, 0)]
        [TestCase(2222, 0, 0)]
        [TestCase(9999, 0, 0)]
        [TestCase(1111, -100, -90)]
        [TestCase(2222, -100, -90)]
        [TestCase(9999, -100, -90)]
        public void ApplyDiscountForSilverCustomer_ReturnDiscountedPrice(int customerId, double amount, double expectedDiscount)
        {
            double silverDiscountPercent = 10;
            ICustomer customer = new SilverCustomer(customerId, silverDiscountPercent);
            DiscountService discountService = new DiscountService(customer);
            var result = discountService.ApplyDiscount(amount);
            Assert.AreEqual(result, expectedDiscount);
        }

        [Test]
        [TestCase(1121,100,100)]
        [TestCase(1412,0,0)]
        [TestCase(1023,-100,-100)]
        public void ApplyDiscountForDefaultCustomer_ReturnDiscountedPrice(int customerId, double amount, double expectedDiscount)
        {
            double defaultDiscountPercent = 0;
            ICustomer customer = new DefaultCustomer(customerId, defaultDiscountPercent);
            DiscountService discountService = new DiscountService(customer);
            var result = discountService.ApplyDiscount(amount);
            Assert.AreEqual(result, expectedDiscount);
        }


     
    }
}