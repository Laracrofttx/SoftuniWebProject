namespace BakerySystem.Web
{
	using BakerySystem.Data.Models;
	using BakerySystem.Web.Data;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.Home;
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


			string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			builder.Services.AddDbContext<BakeryDbContext>(options =>
				options.UseSqlServer(connectionString));

			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
			{

				options.SignIn.RequireConfirmedAccount = false;
			})
				.AddEntityFrameworkStores<BakeryDbContext>();

			builder.Services.AddControllersWithViews();

			WebApplication app = builder.Build();


			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");

				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapDefaultControllerRoute();
			app.MapRazorPages();

			app.Run();
		}
	}
}