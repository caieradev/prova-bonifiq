using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class BaseService
    {
		protected readonly TestDbContext _ctx;
        //TODO: Add main repository
		public BaseService(TestDbContext ctx) { _ctx = ctx; }
    }
}