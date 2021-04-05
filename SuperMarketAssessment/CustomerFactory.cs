namespace SuperMarketAssessment
{
    public abstract class CustomerFactory
    {
        public abstract ICustomer GetCustomer();
    }
    public class PlatinumCustomerFactory : CustomerFactory
    {
        private int customerId;
        private double discountPercent;

        public PlatinumCustomerFactory(int customerId, double discountPercent)
        {
            this.customerId = customerId;
            this.discountPercent = discountPercent;
        }

        public override ICustomer GetCustomer()
        {
            return new platinumCustomer(customerId, discountPercent);
        }
    }

    public class GoldCustomerFactory : CustomerFactory
    {
        private int customerId;
        private double discountPercent;

        public GoldCustomerFactory(int customerId, double discountPercent)
        {
            this.customerId = customerId;
            this.discountPercent = discountPercent;
        }

        public override ICustomer GetCustomer()
        {
            return new GoldCustomer(customerId, discountPercent);
        }
    }

    public class SilverCustomerFactory : CustomerFactory
    {
        private int customerId;
        private double discountPercent;

        public SilverCustomerFactory(int customerId, double discountPercent)
        {
            this.customerId = customerId;
            this.discountPercent = discountPercent;
        }

        public override ICustomer GetCustomer()
        {
            return new SilverCustomer(customerId, discountPercent);
        }
    }

    public class DefaultCustomerFactory : CustomerFactory
    {
        private int customerId;
        private double discountPercent;

        public DefaultCustomerFactory(int customerId, double discountPercent)
        {
            this.customerId = customerId;
            this.discountPercent = discountPercent;
        }

        public override ICustomer GetCustomer()
        {
            return new DefaultCustomer(customerId, discountPercent);
        }
    }
}
 
