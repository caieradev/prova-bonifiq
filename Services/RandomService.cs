﻿namespace ProvaPub.Services
{
	public class RandomService : IService
	{
		public int seed { get; set; }
		public RandomService() { }
		public int GetRandom()
		{
			this.seed = Guid.NewGuid().GetHashCode();
			return new Random(this.seed).Next(100);
		}
	}
}
