namespace ProvaPub.Models
{
	public class ProductList : IList//<Product>
	{
		// I would like to create a generic class, to do not have to create any attribute here,
		// but I will keep the "Products" attribute name because I have no more infos about where the API will be consumed
		public List<Product> Products { get; set; }
    }
}
