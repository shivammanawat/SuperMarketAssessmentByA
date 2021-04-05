using Moq;
using NUnit.Framework;
using SuperMarketAssessment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketUnitTest
{
    [TestFixture]
    public class ShoppingServiceTests
    {
        ShoppingService shoppingService;
        private Mock<ILogger> _logger;
        private Mock<IDiscountService> _discountService;
        private Mock<IPaymentGateway> _paymentGateWay;
        private Mock<IStockRepository> _stockRepository;
      
        private int anycustomerId = 1234;
        public List<Product> products = new List<Product>(){
           new Product()
        {
            Name = "Breads",
                Price = 25,
           },
           new Product()
            {
                Name = "Milk",
                Price = 50,
            },
       
       };
        public  List<string> items = new List<string>()
        {
            "Breads",
            "Milk",
            "Cheese",
            "Butter",
            "Biscuits",
            "Dryfruits"
        };
      

        [SetUp]
        public void SetUp()
        {
            _discountService = new Mock<IDiscountService>();
            _paymentGateWay = new Mock<IPaymentGateway>();
            _stockRepository = new Mock<IStockRepository>();
            _logger = new Mock<ILogger>();
            shoppingService = new ShoppingService(anycustomerId, _stockRepository.Object, _discountService.Object, _paymentGateWay.Object, _logger.Object);
        }


        [Test]
        public void WhenCalledBuyItem_PaymentSuccessfulForAvailableItemsInStock_ReturnsItemCount()
        {
            _stockRepository.Setup(x => x.CheckStockStatus(It.IsAny<List<string>>())).Returns(products);
            _discountService.Setup(x => x.ApplyDiscount(It.IsAny<double>())).Returns(It.IsAny<double>());
            _paymentGateWay.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
            _logger.Setup(x => x.write(It.IsAny<string>()));
            var result = shoppingService.BuyItems(items);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void WhenCalledBuyItem_PaymentFailedDueToBadRequest_ThrowsException()
        {
            _stockRepository.Setup(x => x.CheckStockStatus(It.IsAny<List<string>>())).Returns(products);
            _discountService.Setup(x => x.ApplyDiscount(It.IsAny<double>())).Returns(It.IsAny<double>());
            _paymentGateWay.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest)));
            _logger.Setup(x => x.write(It.IsAny<string>()));
             Assert.Throws<ArgumentException>(() => shoppingService.BuyItems(items));
        }

        [Test]
        public void WhenCalledBuyItem_ErrorInPaymentProcessing()
        {
            _stockRepository.Setup(x => x.CheckStockStatus(It.IsAny<List<string>>())).Returns(products);
            _discountService.Setup(x => x.ApplyDiscount(It.IsAny<double>())).Returns(70);
            _paymentGateWay.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound)));
            _logger.Setup(x => x.write(It.IsAny<string>()));
            var result = shoppingService.BuyItems(items);
            var output = new StringWriter();
            Console.SetOut(output);
            var logger = new Logger();
            var errorMsg = "Error in processing payment " + anycustomerId;
            logger.write(errorMsg); 
            Assert.That(output.ToString(), Is.EqualTo(errorMsg + string.Format(Environment.NewLine)));
            Assert.AreEqual(2, result);
        }


    }
}

       
