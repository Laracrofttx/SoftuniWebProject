namespace BakerySystem.Web
{
	using System.Reflection;

	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	using BakerySystem.Web.Data;
	using BakerySystem.Data.Models;
	using BakerySystem.Services;
	using Infrastructure.Extensions;
	//using BakerySystem.Web.Infrastructure.ModelBinders;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Services.Mapping;
	

	using BakerySystem.Web.ViewModels.Home;
	using static BakerySystem.Common.GeneralApplicationConstants;

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
				.AddRoles<IdentityRole<Guid>>()
				.AddEntityFrameworkStores<BakeryDbContext>();

			builder.Services.AddApplicationServices(typeof(IProductService));

			////builder.Services.AddScoped<IProductService, ProductService>();
			////builder.Services.AddScoped<ICategoryService, CategoryService>();
			////builder.Services.AddScoped<IOrderService, OrderService>();

			//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			
			builder.Services.ConfigureApplicationCookie(config =>
			{
				config.LoginPath = "/User/Login";

			});

			builder.Services.AddRecaptchaService();

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

			AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

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

			app.SeedAdministrator(AdminEmail);

			app.UseEndpoints(config =>
			{
				config.MapControllerRoute(
					name: "areas",
					pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);

				config.MapControllerRoute(
					name: "ProtectingUrlRoute",
					pattern: "/{controller}/{action}/{id}/{information}",
					defaults: new { Controller = "Product", Action = "Details" });

				config.MapDefaultControllerRoute();

				config.MapRazorPages();
			});

			app.Run();
		}
	}
}