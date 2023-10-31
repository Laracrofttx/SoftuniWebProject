namespace BakerySystem.Services
{
    using BakerySystem.Data.Models;
    using BakerySystem.Services.Interfaces;
    using BakerySystem.Web.Data;
    using BakerySystem.Web.ViewModels.Order;

    public class OrderService : IOrderService
    {
        private readonly BakeryDbContext dbContext;

        public OrderService(BakeryDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        public async Task CheckoutOrder(CheckoutViewModel order)
        {

            var submitOrder = new OrderDetail()
            {
                Id = order.Id,
                FirstName = order.FirstName,
                LastName = order.LastName,
                PhoneNumber = order.PhoneNumber,
                Address = order.Address,


            };

            await this.dbContext.OrderDetails.AddAsync(submitOrder);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
