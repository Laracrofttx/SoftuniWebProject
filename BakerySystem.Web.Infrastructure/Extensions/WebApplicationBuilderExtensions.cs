
namespace BakerySystem.Web.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using BakerySystem.Services;
    using BakerySystem.Services.Interfaces;
    using System.Reflection;

    public static class WebApplicationBuilderExtensions
    {
        /// <summary>
        /// This method registers all services with their interfaces and implementation of given assembly
        /// </summary>
        /// <param name="serviceType">Type of any service implementation</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// 
        public static void ApplicationsServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);

            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type!");
            }

            Type[] serviceTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();
            foreach (Type st in serviceTypes)
            {
                Type? interfaceType = st
                    .GetInterface($"I{st.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException("No service provided");
                }

                services.AddScoped(serviceType, st);
            }

            services.AddScoped<IProductService, ProductService>();

        }

    }
}
