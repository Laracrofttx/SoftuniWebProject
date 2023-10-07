﻿namespace BakerySystem.Web.ViewModels.ShoppingCart
{
	public class CartItemViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string Image { get; set; } = null!;

		public decimal Price { get; set; }

		public decimal TotalPrice { get; set; }

		public int Quantity {  get; set; }

		
	}
}