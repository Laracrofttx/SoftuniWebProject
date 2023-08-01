namespace BakerySystem.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;


	public class OrderDetail
	{
		[Key]
		public int Id { get; set; }

		public int TotalPrice { get; set; }

		public int OrderId { get; set; }

		public Order Orders { get; set; } = null!;

		public int ProductId { get; set; }

		public Product Products { get; set; } = null!;

		
	}
}
