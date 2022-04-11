using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeSheets.GB.Controllers.Models;
using TimeSheets.GB.Services.Interfaces;

namespace TimeSheets.GB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IService<ContractDto> _service;

        public ContractsController(IService<ContractDto> service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllContracts()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetContractById([FromRoute]int contractId)
        {
            return Ok(await _service.Get(contractId));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterContract([FromBody]ContractDto contract)
        {
            return (IActionResult)Ok(await _service.Create(contract));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateContract([FromRoute]int contractId, [FromBody]ContractDto contract)
        {
            return Ok(await _service.Update(contractId, contract));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteContractById([FromRoute]int contractId)
        {
            return Ok(await _service.Delete(contractId));
        }
    }
}
