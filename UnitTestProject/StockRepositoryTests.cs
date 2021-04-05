using Moq;
using NUnit.Framework;
using SuperMarketAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketUnitTest
{
    [TestFixture]
    public class StockRepositoryTests
    {
     
        public List<Product> products = new List<Product>();
        public List<string> items = new List<string>();
       

        [Test]
        public void CheckStockStatus_ReturnItemsAreAvailable()
        {
            products.Clear();
            products.Add(new Product()
            {
                Name = "Biscuits",
                Price = 25,
            });
            products.Add(new Product()
            {
                Name = "Milk",
                Price = 50,
            });
            items.Clear();
            items.Add("Bread");
            items.Add("Milk");
            items.Add("cheese");
            items.Add("Butter");
            items.Add("Biscuits");
            Mock<IStockRepository> mockStock = new Mock<IStockRepository>();
            mockStock.Setup(x => x.CheckStockStatus(It.IsAny<List<string>>())).Returns(products);
            Stock stock = new Stock(mockStock.Object);
            var result = stock.CheckStockStatus(items);
            Assert.AreEqual(products, result);
        }

       [Test]
        public void CheckStockStatus_ItemsNotAvailable()
        {
            products.Clear();
            products.Add(new Product()
            {
                Name = "Biscuits",
                Price = 25,
            });
            products.Add(new Product()
            {
                Name = "Milk",
                Price = 50,
            });
            items.Clear();
            items.Add("Bread");
            items.Add("Milk");
            items.Add("cheese");
            items.Add("Butter");
            items.Add("Biscuits");
            Mock<IItemStatus> mockItemStatus = new Mock<IItemStatus>();
            var stockRepository = new StockRepository(mockItemStatus.Object);
            mockItemStatus.Setup(x => x.productInStock(It.IsAny<Random>())).Returns(false);
            var result = stockRepository.CheckStockStatus(items).Count();
            Assert.That(result, Is.EqualTo(0));

        }
    }
}

    

