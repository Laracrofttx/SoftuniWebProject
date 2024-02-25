﻿namespace BakerySystem.Services.Tests
{
	using BakerySystem.Data.Models;
	using BakerySystem.Web.Data;
	public static class DataBaseSeeder
	{
		public static ApplicationUser ApplicationUsers;
		public static Product Products;
		public static Category Categories;
		public static WeAreHiring Possitions;

        public static void SeedDataBase(BakeryDbContext dbContext)
		{
			

			ApplicationUsers = new ApplicationUser()
			{
				UserName = "Pesho Petrov",
				NormalizedUserName = "PESHO@ABV.BG",
				Email = "pesho@abv.bg",
				NormalizedEmail = "PESHO@ABV.BG",
				EmailConfirmed = true,
				PasswordHash = "AQAAAAEAACcQAAAAEJW96DG2bC8COzd5Q6R8wuby/EQSfum+SCF7nMc4xmCsQCS25LQcErcKY573eSWjAQ",
				SecurityStamp = "42V34ZUKMWVDS6S33BAFAQ2AGWXSJFAX",
				ConcurrencyStamp = "38d8a2c8-3c94-43fa-8bb1-a1ac4696d19c",
				FirstName = "Pesho",
				LastName = "Petrov",

			};

			Products = new Product()
			{

				Name = "Bagel",
				Price = 1.50m,
				Description = "Delicious",
				IsAvailable = true,
				ImageUrl = "data:image/jpeg;base64,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"


			};


			Categories = new Category()
			{
				Name = "Breads",
				IsAvailable = true,

			};

			Possitions = new WeAreHiring()
			{

				PositionName = "Baker",
				Salary = 1650m,
				JobDescription = "Prepare and bake everything",
				ImageUrl = "data:image/jpeg;base64,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"


			};

			dbContext.Users.Add(ApplicationUsers);
			dbContext.Products.Add(Products);
			dbContext.Categories.Add(Categories);
			dbContext.WeAreHirings.Add(Possitions);

			dbContext.SaveChanges();
		}

	}
}
