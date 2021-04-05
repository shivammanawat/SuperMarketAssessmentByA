namespace SuperMarketAssessment
{

   
public class GoldCustomer : ICustomer
    {
        public int Id { get; set; }
        public double discountPercent { get; set; }

        public GoldCustomer(int id, double discountPercent)
        {
            this.Id = id;
            this.discountPercent = discountPercent;
        }

     
    }


}
