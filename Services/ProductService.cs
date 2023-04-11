using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService : BaseService
	{
		public ProductService(TestDbContext ctx) : base(ctx) { }

		//TODO: Create ProductRepository
		public ProductList ListProducts(int page)
		{
			var data = _ctx.Products
					.OrderBy(x => x.Id)
					.Skip((page -1) * 10)
					.Take(10)
					.ToList();

			return new ProductList() {  
				HasNext = _ctx.Products.Skip(page * 10).Count() > 0,
				TotalCount = data.Count(), 
				Products = data
			};
		}
	}
}
