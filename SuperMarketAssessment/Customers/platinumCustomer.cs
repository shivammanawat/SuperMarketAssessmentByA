namespace SuperMarketAssessment
{
    public class platinumCustomer : ICustomer
    {
        public int Id { get; set; }
        public double discountPercent { get; set; }
        public platinumCustomer(int id, double discountPercent)
        {
            this.Id = id;
            this.discountPercent = discountPercent;
        }

       
    }


}
