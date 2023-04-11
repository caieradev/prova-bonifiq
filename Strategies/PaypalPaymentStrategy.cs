namespace ProvaPub.Strategies;

public class PaypalPaymentStrategy : IPaymentStrategy
{
    public string PaymentMethod = "paypal";
    public override async Task<bool> Pay(decimal value, int customerId)
    {
        // Faz pagamento pelo Paypal...
        return true;
    }
}