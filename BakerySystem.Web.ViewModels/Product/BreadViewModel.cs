﻿namespace BakerySystem.Web.ViewModels.Product
{
    public class BreadViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;
    }
}
