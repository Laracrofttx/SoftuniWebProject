namespace BakerySystem.Web.Data
{
	using BakerySystem.Data.Configurations;
	using BakerySystem.Data.Models;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.Data.SqlClient;
	using Microsoft.EntityFrameworkCore;
	using System.Reflection;

	public class BakeryDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		public BakeryDbContext(DbContextOptions<BakeryDbContext> options)
			: base(options)
		{
			
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<ContactUs> ContactUs { get; set; }

		public DbSet<DailyOffert> DailyOfferts { get; set; }

		public DbSet<OrderDetail> OrderDetails { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<WeAreHiring> WeAreHirings { get; set; }

		public DbSet<JobApplication> JobApplications { get; set; }

		public DbSet<Review> Reviews { get; set; }

		public DbSet<Cart> Carts { get; set; }

		public DbSet<CartItem> CartItems { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder
				.Entity<Product>()
				.HasOne(c => c.Category)
				.WithMany(c => c.Products)
				.HasForeignKey(c => c.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);

			
			Assembly configAssembly = Assembly.GetAssembly(typeof(BakeryDbContext)) ??
									  Assembly.GetExecutingAssembly();

			builder.ApplyConfigurationsFromAssembly(configAssembly);

			base.OnModelCreating(builder);




		}
	}
}