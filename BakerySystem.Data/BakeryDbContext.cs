
namespace BakerySystem.Web.Data
{
    using BakerySystem.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class BakeryDbContext : IdentityDbContext<ApplicationUser>
    {
        public BakeryDbContext(DbContextOptions<BakeryDbContext> options)
            : base(options)
        {
        }
    }
}