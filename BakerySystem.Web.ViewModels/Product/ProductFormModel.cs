using BakerySystem.Data.Models;
using System.ComponentModel.DataAnnotations;

using static BakerySystem.Common.EntityValidationConstants.Products;

namespace BakerySystem.Web.ViewModels.Product
{
    public class ProductFormModel
    {
        public ProductFormModel()
        {
            this.Categories = new HashSet<ProductCategoryViewModel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "The field Name must be a string with a minimum length of {2}")]
        public string Name { get; set; } = null!;

        
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; } 

        [Required]
        [Display(Name = "Image")]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(int.MaxValue,MinimumLength = DescriptionMinLength, ErrorMessage = "The field Description must be a string with a minimum length of {2}")]
        public string Description { get; set; } = null!;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ProductCategoryViewModel> Categories { get; set; } = null!;
    }
}
