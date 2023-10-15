namespace BakerySystem.Web
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.Infrastructure.Extensions;
	using Microsoft.AspNetCore.Identity;
	//using BakerySystem.Web.Infrastructure.ModelBinders;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	
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

				options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

				options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
				options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
				options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
				options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
			})
				.AddEntityFrameworkStores<BakeryDbContext>();

			builder.Services.AddApplicationServices(typeof(IProductService));

			//builder.Services.AddScoped<IProductService, ProductService>();
			//builder.Services.AddScoped<ICategoryService, CategoryService>();
			//builder.Services.AddScoped<IOrderService, OrderService>();

			builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			

			builder.Services.AddMemoryCache();
			builder.Services.AddResponseCaching();

			builder.Services.ConfigureApplicationCookie(config =>
			{
				config.LoginPath = "/User/Login";

			});
			
			builder.Services.AddMemoryCache();
			builder.Services.AddResponseCaching();

			builder.Services.ConfigureApplicationCookie(cfg =>
			{
				cfg.LoginPath = "/User/Login";
				cfg.AccessDeniedPath = "/Home/Error/401";
			});

			builder.Services
				.AddControllersWithViews()
				.AddMvcOptions(options =>
				{

					//options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
					options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();

				});


			WebApplication app = builder.Build();


			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error/500");
				app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseResponseCaching();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapDefaultControllerRoute();

			app.MapRazorPages();

			app.Run();
		}
	}
}