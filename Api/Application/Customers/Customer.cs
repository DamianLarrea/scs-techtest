namespace Application.Customers
{
    public class Customer
    {
        public Customer(Guid id, string firstName, string lastName, string email, string mobile, string address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Mobile = mobile;
            Address = address;
        }

        public Guid Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Mobile { get; }

        public string Address { get; }
    }
}
