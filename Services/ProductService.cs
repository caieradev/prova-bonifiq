using ProvaPub.Models;
using ProvaPub.Repositories;

namespace ProvaPub.Services
{
	public class ProductService : BaseService<ProductRepository>, IService
	{
		public ProductService(ProductRepository repository) : base(repository) { }

		//TODO: Create ProductRepository
		public async Task<ProductList> ListProducts(int page)
		{
			List<Product> data = await this._mainRepository.GetList(page, 10);
            var hasNext = data.Count() >= 11;

            data = data
                .Take(10)
                .ToList();

			return new ProductList() {  
				HasNext = hasNext,
				TotalCount = data.Count(), 
				Products = data
			};
		}
	}
}
