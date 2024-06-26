﻿namespace BakerySystem.Web.Infrastructure.Extensions
{
	using System.Reflection;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Identity;
	using BakerySystem.Data.Models;
	using static Common.GeneralApplicationConstants;
	public static class WebApplicationBuilderExtensions
	{
		/// <summary>
		/// This method registers all services with their interfaces and implementation of given assembly
		/// </summary>
		/// <param name="serviceType">Type of any service implementation</param>
		/// <exception cref="InvalidOperationException"></exception>
		/// 
		public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
		{
			Assembly? serviceAssembly = Assembly.GetAssembly(serviceType) ?? throw new InvalidOperationException("Invalid service type!");

			Type[] implementationTypes = serviceAssembly
				.GetTypes()
				.Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
				.ToArray();
			foreach (Type implementationType in implementationTypes)
			{
				Type? interfaceType = implementationType
					.GetInterface($"I{implementationType.Name}") ?? throw new InvalidOperationException($"No interface provided for the service name: {implementationType.Name}");

				services.AddScoped(interfaceType, implementationType);
			}
		}
		public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
		{
			using IServiceScope scopedServices =
				app.ApplicationServices.CreateScope();

			IServiceProvider serviceProvider =
				scopedServices.ServiceProvider;

			UserManager<ApplicationUser> userManager =
				serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

			RoleManager<IdentityRole<Guid>> roleManager =
				serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

			Task.Run(async () =>
			{
				if (await roleManager.RoleExistsAsync(AdminRoleName))
				{
					return;
				}

				IdentityRole<Guid> role = new(AdminRoleName);

				await roleManager.CreateAsync(role);

				ApplicationUser adminUser = await userManager.FindByEmailAsync(email);

				await userManager.AddToRoleAsync(adminUser, AdminRoleName);

			})
				.GetAwaiter()
				.GetResult();

			return app;
		}
	}
}
