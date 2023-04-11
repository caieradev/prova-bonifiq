using Microsoft.EntityFrameworkCore;

namespace ProvaPub.Repositories
{
    public class OrderRepository : IRepository
    {
		private readonly TestDbContext _ctx;
        public OrderRepository(TestDbContext ctx) { this._ctx = ctx; }
        
        public async Task<bool> HasOrdersInThisMonth(int customerId) =>
            await this._ctx.Orders
                .AnyAsync(x => x.CustomerId == customerId && 
                               x.OrderDate >= DateTime.UtcNow.AddMonths(-1));
    }
}