namespace BakerySystem.WebApi
{
	using BakerySystem.Services;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using Microsoft.EntityFrameworkCore;
	using Web.Infrastructure.Extensions;
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

			builder.Services.AddDbContext<BakeryDbContext>(opt => opt.UseSqlServer(connectionString));

			builder.Services.AddApplicationServices(typeof(IProductService));

			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			
			builder.Services.AddCors(setup =>
			{

				setup.AddPolicy("BakerySystem", policyBuilder =>
				{

					policyBuilder
					.WithOrigins("https://localhost:7158")
					.AllowAnyHeader()
					.AllowAnyMethod();
					
				});

			});
				

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.UseCors("BakerySystem");

			app.Run();
		}
	}
}