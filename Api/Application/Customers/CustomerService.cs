namespace Application.Customers
{
    public interface ICustomerService
    {
        void AddCustomer(string firstName, string lastName, string email, string mobile, string address);

        IReadOnlyCollection<Customer> GetAll();

        Customer? GetById(Guid id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IReadOnlyCollection<Customer> GetAll() => customerRepository.Get();

        public Customer? GetById(Guid id) => customerRepository.Get(id);

        public void AddCustomer(string firstName, string lastName, string email, string mobile, string address)
        {
            if (firstName == string.Empty) throw new ArgumentException($"{nameof(firstName)} must have a value.");

            if (lastName == string.Empty) throw new ArgumentException($"{nameof(lastName)} must have a value.");

            if (email == string.Empty) throw new ArgumentException($"{nameof(email)} must have a value.");

            if (mobile == string.Empty) throw new ArgumentException($"{nameof(mobile)} must have a value.");

            if (address == string.Empty) throw new ArgumentException($"{nameof(address)} must have a value.");

            customerRepository.Add(new Customer(Guid.NewGuid(), firstName, lastName, email, mobile, address));
        }
    }
}
