using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeSheets.GB.Controllers.Models;
using TimeSheets.GB.Services.Interfaces;

namespace TimeSheets.GB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IService<CustomerDto> _service;

        public CustomersController(IService<CustomerDto> service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute]int customerId)
        {
            return Ok(await _service.Get(customerId));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody]CustomerDto customer)
        {
            return Ok(await _service.Create(customer));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute]int customerId, [FromBody]CustomerDto customer)
        {
            return Ok(await _service.Update(customerId, customer));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute]int customerId)
        {
            return Ok(await _service.Delete(customerId));
        }
    }
}
