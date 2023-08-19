using BakerySystem.Data.Models;
using BakerySystem.Services.Interfaces;
using BakerySystem.Web.Data;
using BakerySystem.Web.ViewModels.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;

namespace BakerySystem.Services
{
	public class OrderService : IOrderService
	{
		private readonly BakeryDbContext dbContext;

		public OrderService(BakeryDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<OrderViewModel>> OrderHistory()
		{

			IEnumerable<OrderViewModel> orderHistory = await this.dbContext
				.Orders
				.Select(o => new OrderViewModel()
				{

					OrderId = o.Id,
					FirstName = o.FirstName,
					LastName = o.LastName,
					Address = o.Address,
					PhoneNumber = o.PhoneNumber



				}).ToArrayAsync();


			return orderHistory;



		}



		public async Task<IEnumerable<OrderViewModel>> Order()
		{

			IEnumerable<OrderViewModel> order = await this.dbContext
				.Orders
				.Select(o => new OrderViewModel()
				{

					OrderId = o.Id,
					FirstName = o.FirstName,
					LastName = o.LastName,
					Address = o.Address,
					PhoneNumber = o.PhoneNumber



				}).ToArrayAsync();


			return order;


		}


	


	}
}
