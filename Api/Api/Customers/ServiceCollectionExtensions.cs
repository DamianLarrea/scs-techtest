using Application.Customers;
using Data.Customers;

namespace Api.Customers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomerControllerDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddTransient<ICustomerService, CustomerService>();

            return serviceCollection;
        }
    }
}
