using System.Reflection;
using ProvaPub.Models;
using ProvaPub.Strategies;

namespace ProvaPub.Services
{
	public class OrderService
	{
		private readonly IDictionary<string, IPaymentStrategy> _paymentStrategies = new Dictionary<string, IPaymentStrategy>();
		
		public OrderService(CreditCardPaymentStrategy creditCardPaymentStrategy, PaypalPaymentStrategy paypalPaymentStrategy, PixPaymentStrategy pixPaymentStrategy)
		{
			_paymentStrategies.Add(creditCardPaymentStrategy.PaymentMethod, creditCardPaymentStrategy);
			_paymentStrategies.Add(paypalPaymentStrategy.PaymentMethod, paypalPaymentStrategy);
			_paymentStrategies.Add(pixPaymentStrategy.PaymentMethod, pixPaymentStrategy);
		}

		public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
		{
			if (!_paymentStrategies.ContainsKey(paymentMethod))
			{
				throw new ArgumentException($"Método de pagamento inválido: {paymentMethod}");
			}

			var paymentStrategy = _paymentStrategies[paymentMethod];

			if (!(await paymentStrategy.Pay(paymentValue, customerId)))
				throw new Exception("Ocorreu um erro ao processar o pagamento");

			return new Order()
			{
				Value = paymentValue
			};
		}
	}

}
