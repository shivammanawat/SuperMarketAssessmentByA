using System.Threading.Tasks;
using System.Net.Http;

namespace SuperMarketAssessment
{
    public interface IPaymentGateway
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}
