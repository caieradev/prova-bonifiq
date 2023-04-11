using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaPub.Models
{
    public abstract class IList//<T>
    {
        // public List<T> Elements { get; set; }
		public int TotalCount { get; set; }
		public bool HasNext { get; set; }
    }
}