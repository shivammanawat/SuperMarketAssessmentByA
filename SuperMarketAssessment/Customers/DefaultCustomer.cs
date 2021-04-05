namespace SuperMarketAssessment
{
    public class DefaultCustomer : ICustomer
    {
        public int Id { get; set; }
        public double discountPercent { get; set; }
        public DefaultCustomer(int id, double discountPercent)
        {
            this.Id = id;
            this.discountPercent = discountPercent;
        }
      
    }


}
