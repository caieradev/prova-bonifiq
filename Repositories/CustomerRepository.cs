using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;

namespace ProvaPub.Repositories
{
    public class CustomerRepository : IRepository
    {
		private readonly TestDbContext _ctx;
        public CustomerRepository(TestDbContext ctx) { this._ctx = ctx; }

        public async Task<List<Customer>> GetList(int page, int take) =>
            await this._ctx.Customers
                .OrderBy(x => x.Id)
                .Skip((page -1) * take)
                .Take(take + 1)
                .ToListAsync();
        public async Task<Customer?> FindAsync(int id) =>
            await this._ctx.Customers.FindAsync(id);

        public async Task<bool> CustomerHaveBoughtBefore(int customerId) =>
            await this._ctx.Customers
                .AnyAsync(s => s.Id == customerId && s.Orders.Any());
    }
}