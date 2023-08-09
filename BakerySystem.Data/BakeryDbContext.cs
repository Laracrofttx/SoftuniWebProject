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
        private readonly bool seedDb;

        public BakeryDbContext(DbContextOptions<BakeryDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<ContactUs> ContactUs { get; set; } = null!; 

        public DbSet<DailyOffert> DailyOfferts { get; set; } = null!;

        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;        

        public DbSet<WeAreHiring> WeAreHirings { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;


		protected override void OnModelCreating(ModelBuilder builder)
		{

            
            //builder.ApplyConfiguration(new ProductConfiguration());
            Assembly configAssembly = Assembly.GetAssembly(typeof(BakeryDbContext)) ??
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            
            base.OnModelCreating(builder);

           SaveChangesAsync();
            
		}
	}
}