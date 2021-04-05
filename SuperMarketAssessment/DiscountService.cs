namespace SuperMarketAssessment
{

    public class DiscountService : IDiscountService
    {
        public ICustomer customer;
        public DiscountService(ICustomer customer)
        {
            this.customer = customer;
        }
        public double ApplyDiscount(double totalPrice)
        {
            return totalPrice - (totalPrice * customer.discountPercent / 100);
           
        }


    }
}
