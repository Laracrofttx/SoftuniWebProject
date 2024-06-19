namespace BakerySystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;
	public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.Property(u => u.FirstName)
				.HasDefaultValue("Unknown");

			builder.Property(u => u.LastName)
				.HasDefaultValue("User");
		}
	}
}

