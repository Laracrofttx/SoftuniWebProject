namespace BakerySystem.Web.ViewModels.Order
{
	public class OrderViewModel
	{
		public int OrderId { get; set; }

		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;

	    public string Address { get; set; } = null!;

		public string PhoneNumber { get; set; } = null!;
	}
}
