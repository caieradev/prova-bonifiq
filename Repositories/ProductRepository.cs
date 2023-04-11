using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;

namespace ProvaPub.Repositories
{
    public class ProductRepository : IRepository
    {
		private readonly TestDbContext _ctx;
        public ProductRepository(TestDbContext ctx) { this._ctx = ctx; }

        public async Task<List<Product>> GetList(int page, int take) =>
            await this._ctx.Products
                .OrderBy(x => x.Id)
                .Skip((page -1) * take)
                .Take(take + 1)
                .ToListAsync();
    }
}