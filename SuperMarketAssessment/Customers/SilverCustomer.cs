namespace SuperMarketAssessment
{
    public class SilverCustomer : ICustomer
    {
        public int Id { get; set; }
        public double discountPercent { get; set; }
        public SilverCustomer(int id, double discountPercent)
        {
            this.Id = id;
            this.discountPercent = discountPercent;
        }
     
    }


}
