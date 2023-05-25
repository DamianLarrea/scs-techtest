namespace Application.Customers
{
    public interface ICustomerRepository
    {
        public void Add(Customer customer);

        public IReadOnlyCollection<Customer> Get();

        public Customer? Get(Guid id);
    }
}
