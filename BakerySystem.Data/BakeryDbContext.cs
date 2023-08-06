namespace BakerySystem.Web.Data
{
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

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }   

        public DbSet<WeAreHiring> WeAreHirings { get; set; }

        public DbSet<Review> Reviews { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{

            SaveChangesAsync();

            Assembly configAssembly = Assembly.GetAssembly(typeof(BakeryDbContext)) ??
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

           
            base.OnModelCreating(builder);
            
		}
	}
}