using Application.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            return customerService.GetAll().Select(Map);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var customer = customerService.GetById(id);

            return customer is null ? NotFound() : new JsonResult(Map(customer));
        }

        [HttpPost]
        public void Post([FromBody] CustomerDto dto)
        {
            customerService.AddCustomer(dto.FirstName, dto.LastName, dto.Email, dto.Mobile, dto.Address);
        }

        private CustomerDto Map(Customer customer) => new()
        {
            Id = customer.Id,
            Address = customer.Address,
            Email = customer.Email,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Mobile = customer.Mobile
        };
    }
}
