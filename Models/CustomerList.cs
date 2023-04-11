namespace ProvaPub.Models
{
	public class CustomerList : IList//<Product>
	{
		// I would like to create a generic class, to do not have to create any attribute here,
		// but I will keep the "Custumers" attribute name because I have no more infos about where the API will be consumed
		public List<Customer> Customers { get; set; }
	}
}
