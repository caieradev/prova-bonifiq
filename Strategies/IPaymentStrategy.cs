namespace ProvaPub.Strategies
{
    public abstract class IPaymentStrategy
    {
        public string PaymentMethod { get; set; }
        public abstract Task<bool> Pay(decimal value, int customerId);
    }

}