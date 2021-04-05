using Moq;
using Moq.Protected;
using NUnit.Framework;
using SuperMarketAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestFixture]
    public class PaymentGatewayTests
    {
       
        
        [Test]

        public void WhenCalledPaymentGateway_ReturnsPaymentIsSuccessful()
        {
            var mockHandler = new Mock<HttpMessageHandler>();
            var requestUri = "http://www.google.com/search?q=7.0";
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            mockHandler.Protected()
                       .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                       .ReturnsAsync(response);

            var httpClient = new HttpClient(mockHandler.Object);
            var paymentGateway = new PaymentGateway(httpClient);
            var retrievedPosts = paymentGateway.GetAsync(requestUri);
            Assert.NotNull(retrievedPosts);

            mockHandler.Protected().Verify(
               "SendAsync",
               Times.Exactly(1),
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
               ItExpr.IsAny<CancellationToken>());

        }

    }
}
