using System.Collections.Generic;

namespace SuperMarketAssessment
{
    public interface IShoppingService
    {
        int BuyItems(List<string> items);
    }


}