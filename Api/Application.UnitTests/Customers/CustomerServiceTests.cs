using Application.Customers;
using FluentAssertions;
using Moq;

namespace Application.UnitTests.Customers
{
    public class CustomerServiceTests
    {
        private Mock<ICustomerRepository> customerRepositoryMock;
        private CustomerService service;

        [SetUp]
        public void Setup()
        {
            customerRepositoryMock = new Mock<ICustomerRepository>();
            service = new CustomerService(customerRepositoryMock.Object);
        }

        [Test]
        public void GetById_ReturnsNothing_WhenGivenCustomerDoesntExist()
        {
            var id = Guid.NewGuid();

            customerRepositoryMock.Setup(repo => repo.Get(id)).Returns<Customer>(null);

            var customer = service.GetById(id);

            customer.Should().BeNull();
        }

        [Test]
        public void GetById_ReturnsExpectedCustomer_WhenGivenCustomerExists()
        {
            var customer = new Customer(Guid.NewGuid(), "test", "user", "testuser@app.com", "0456789123", "1 George St, Sydney NSW 2000");

            customerRepositoryMock.Setup(repo => repo.Get(customer.Id)).Returns(customer);

            var result = service.GetById(customer.Id);

            result.Should().Be(customer);
        }

        [Test]
        public void GetAll_ReturnsNothing_WhenNoCustomersInTheSystem()
        {
            customerRepositoryMock.Setup(repo => repo.Get()).Returns(new List<Customer>());

            var customers = service.GetAll();

            customers.Should().BeEmpty();
        }

        [Test]
        public void GetAll_ReturnsAllCustomers_WhenCustomersExistInTheSystem()
        {
            var customer = new Customer(Guid.NewGuid(), "test", "user", "testuser@app.com", "0456789123", "1 George St, Sydney NSW 2000");
            customerRepositoryMock.Setup(repo => repo.Get()).Returns(new[] { customer });

            var customers = service.GetAll();

            customers.Should().BeEquivalentTo(new[] { customer });
        }

        [Test]
        public void AddCustomer_SuccessfullyAddsCustomer_WhenAllFieldsAreProvided()
        {
            var customers = new List<Customer>();

            customerRepositoryMock.Setup(repo => repo.Add(It.IsAny<Customer>())).Callback<Customer>(customers.Add);

            service.AddCustomer("test", "user", "testuser@app.com", "0456789123", "1 George St, Sydney NSW 2000");

            customers.Should().HaveCount(1);

            var customer = customers.Single();

            customer.Should().BeEquivalentTo(new Customer(Guid.NewGuid(), "test", "user", "testuser@app.com", "0456789123", "1 George St, Sydney NSW 2000"), opts => opts.Excluding(x => x.Id));
        }

        [TestCase("Test", "User", "testuser@app.com", "0456789123", "")]
        [TestCase("Test", "User", "testuser@app.com", "", "1 George St, Sydney NSW 2000")]
        [TestCase("Test", "User", "", "0456789123", "1 George St, Sydney NSW 2000")]
        [TestCase("Test", "", "testuser@app.com", "0456789123", "1 George St, Sydney NSW 2000")]
        [TestCase("", "User", "testuser@app.com", "0456789123", "1 George St, Sydney NSW 2000")]
        public void AddCustomer_Fails_WhenAnyInputIsEmpty(string firstName, string lastName, string email, string mobile, string address)
        {
            var act = () => service.AddCustomer(firstName, lastName, email, mobile, address);

            act.Should().Throw<ArgumentException>();
        }

    }
}