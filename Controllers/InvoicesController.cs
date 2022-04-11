using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using TimeSheets.GB.Controllers.Models;
using TimeSheets.GB.Services.Interfaces;

namespace TimeSheets.GB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IService<InvoiceDto> _service;

        public InvoicesController(IService<InvoiceDto> service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllInvoices()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetInvoice([FromRoute] int invoiceId)
        {
            return Ok(await _service.Get(invoiceId));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterInvoice([FromBody] InvoiceDto invoice)
        {
            return Ok(await _service.Create(invoice));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateInvoice([FromRoute] int invoiceId, [FromBody] InvoiceDto invoice)
        {
            return Ok(await _service.Update(invoiceId, invoice));
        }

        [HttpDelete("dalete/{id}")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int invoiceId)
        {
            return Ok(await _service.Delete(invoiceId));
        }
    }
}
