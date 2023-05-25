using Microsoft.AspNetCore.Mvc;

namespace Api.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CustomerDto> Get() => new List<CustomerDto>();

        [HttpGet("{id}")]
        public CustomerDto Get(Guid id) => new CustomerDto();

        [HttpPost]
        public void Post([FromBody] CustomerDto dto) { }
    }
}
