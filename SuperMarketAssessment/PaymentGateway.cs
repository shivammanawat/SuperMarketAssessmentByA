using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace SuperMarketAssessment
{

    public class PaymentGateway : IPaymentGateway
    {
        private HttpClient _httpClient;
        public PaymentGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
       

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
          
            var result = await _httpClient.GetAsync(requestUri);

            return result;
           
        }
    }
}
