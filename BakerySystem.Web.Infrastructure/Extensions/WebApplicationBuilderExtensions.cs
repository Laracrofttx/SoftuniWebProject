namespace BakerySystem.Web.Infrastructure.Extensions
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using BakerySystem.Services;
    using BakerySystem.Services.Interfaces;
	using Microsoft.AspNetCore.Builder;

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
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);

            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type!");
            }

            Type[] implementationTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();
            foreach (Type implementationType in implementationTypes)
            {
                Type? interfaceType = implementationType
					.GetInterface($"I{implementationType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No interface provided for the service name: {implementationType.Name}");
                }

                services.AddScoped(interfaceType, implementationType);
            }

        }

        public static void SeedAdministrator(IApplicationBuilder app, string email)
        {

            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;
        
        }

    }
}
