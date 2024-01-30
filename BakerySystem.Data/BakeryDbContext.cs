namespace BakerySystem.Web.Data
{
	using BakerySystem.Data.Models;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;
	using System.Reflection;

	public class BakeryDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		public BakeryDbContext(DbContextOptions<BakeryDbContext> options)
			: base(options)
		{
			
		}

		public DbSet<Category> Categories { get; set; } = null!;

		public DbSet<ContactUs> ContactUs { get; set; } = null!;

		public DbSet<DailyOffert> DailyOfferts { get; set; } = null!;

		public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

		public DbSet<Product> Products { get; set; } = null!;

		public DbSet<WeAreHiring> WeAreHirings { get; set; } = null!;

		public DbSet<JobApplication> JobApplications { get; set; } = null!;

		public DbSet<Review> Reviews { get; set; } = null!;

		public DbSet<Cart> Carts { get; set; } = null!;

		public DbSet<CartItem> CartItems { get; set; } = null!;


		
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