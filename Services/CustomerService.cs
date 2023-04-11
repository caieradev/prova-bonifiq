using ProvaPub.Models;
using ProvaPub.Repositories;

namespace ProvaPub.Services
{
    public class CustomerService : BaseService<CustomerRepository>, IService
    {
		private readonly OrderRepository orderRepository;

        public CustomerService(CustomerRepository repository, OrderRepository _orderRepository) : base(repository) { this.orderRepository = _orderRepository; }

        public async Task<CustomerList> ListCustomers(int page)
        {
            List<Customer> data = await this._mainRepository.GetList(page, 10);
            var hasNext = data.Count() >= 11;

            data = data
                .Take(10)
                .ToList();

			return new CustomerList() {  
				HasNext = hasNext,
				TotalCount = data.Count(), 
				Customers = data
			};
        }

        public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
        {
            if (customerId <= 0) 
                throw new ArgumentOutOfRangeException(nameof(customerId));

            if (purchaseValue <= 0)
                throw new ArgumentOutOfRangeException(nameof(purchaseValue));

            //Business Rule: Non registered Customers cannot purchase
            var customer = await this._mainRepository.FindAsync(customerId);
            if (customer == null)   
                throw new InvalidOperationException($"Customer Id {customerId} does not exists");

            //Business Rule: A customer can purchase only a single time per month
            if (await this.orderRepository.HasOrdersInThisMonth(customerId))
                return false;

            //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00
            if (!(await this._mainRepository.CustomerHaveBoughtBefore(customerId)) && purchaseValue > 100)
                return false;

            return true;
        }

    }
}
