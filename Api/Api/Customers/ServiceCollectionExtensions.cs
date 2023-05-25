using Application.Customers;
using Data.Customers;

namespace Api.Customers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomerControllerDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICustomerRepository, CustomerRepository>();

            return serviceCollection;
        }
    }
}
