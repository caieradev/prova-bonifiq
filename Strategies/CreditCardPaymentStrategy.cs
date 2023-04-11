namespace ProvaPub.Strategies;

public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public string PaymentMethod = "creditcard";
    public override async Task<bool> Pay(decimal value, int customerId)
    {
        // Faz pagamento por cartão de crédito...
        return true;
    }
}