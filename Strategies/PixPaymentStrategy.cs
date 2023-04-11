namespace ProvaPub.Strategies;
public class PixPaymentStrategy : IPaymentStrategy
{
    public string PaymentMethod = "pix";

    public override async Task<bool> Pay(decimal value, int customerId)
    {
        // Faz pagamento por Pix...
        return true;
    }
}
