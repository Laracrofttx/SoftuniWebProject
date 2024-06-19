namespace BakerySystem.Web.ViewModels.Product
{
    using BakerySystem.Web.ViewModels.Category;
    public class ProductIndexViewModel
    {
        public ProductIndexViewModel()
        {
            Products = new HashSet<ProductSearchQueryModel>();
            Categories = new HashSet<CategoryListingViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<ProductSearchQueryModel> Products { get; set; } = null!;
        public IEnumerable<CategoryListingViewModel> Categories { get; set; } = null!;
        public decimal DiscoutPrice { get; set; }
    }
}
