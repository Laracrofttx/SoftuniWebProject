namespace BakerySystem.Services
{
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.DailyOffer;
	using Microsoft.EntityFrameworkCore;

	public class DailyOfferService : IDailyOfferService
	{
		private readonly BakeryDbContext dbContext;

		public DailyOfferService(BakeryDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<DailyOfferViewModel>> DailyOffer()
		{
			var dailyOffer = await this.dbContext
				.Products
				.OrderBy(c => c.Id)
				.Take(8)
				.Select(c => new DailyOfferViewModel
				{
					Id = c.Id,
					Name = c.Name,
					Price = (decimal)Math.Round(c.Price - c.Price * 0.2m, 2),
					ImageUrl = c.ImageUrl,
					Description = c.Description
				})
				.ToArrayAsync();
			
			return dailyOffer;
		}
	}
}
