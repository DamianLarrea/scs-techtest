using Application.Customers;

namespace Data.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers = new();

        public void Add(Customer customer) => customers.Add(customer);

        public IReadOnlyCollection<Customer> Get() => customers;

        public Customer? Get(Guid id) => customers.FirstOrDefault(x => x.Id == id);
    }
}
