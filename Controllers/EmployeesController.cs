using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeSheets.GB.Controllers.Models;
using TimeSheets.GB.Services.Interfaces;

namespace TimeSheets.GB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IService<EmployeeDto> _service;

        public EmployeesController(IService<EmployeeDto> service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute]int employeeId)
        {
            return Ok(await _service.Get(employeeId));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterEmployee([FromBody]EmployeeDto employee)
        {
            return Ok(await _service.Create(employee));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute]int employeeId, [FromBody]EmployeeDto employee)
        {
            return Ok(await _service.Update(employeeId, employee));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute]int employeeId)
        {
            return Ok(await _service.Delete(employeeId));
        }
    }
}
