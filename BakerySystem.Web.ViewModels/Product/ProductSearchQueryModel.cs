namespace BakerySystem.Web.ViewModels.Product
{
	using System.ComponentModel.DataAnnotations;

	
	public class ProductSearchQueryModel
	{
        public ProductSearchQueryModel()
        {
			this.Products = new HashSet<ProductListingVIewModel>();
        }

        public const int ProductsPerPage = 4;

		[Display(Name = "Search by word")]
		public string SearchByName { get; set; } = null!;

		[Display(Name = "Search by price")]
		public decimal Price { get; set; }

		public int CurrentPage { get; set; } = 1;

		public int TotalProducts { get; set; }

		public int CategoryId { get; set; }
		public string CategoryName { get; set; } = null!;

		public IEnumerable<ProductListingVIewModel> Products { get; set; } = null!;
	}
}
