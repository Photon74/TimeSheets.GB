using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TimeSheets.GB.Controllers.Models;
using TimeSheets.GB.Services.Interfaces;

namespace TimeSheets.GB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IService<TaskDto> _service;

        public TasksController(IService<TaskDto> service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllTasks()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetTaskById([FromRoute]int taskId)
        {
            return Ok(await _service.Get(taskId));
        }

        [HttpPost("register")]
        public async Task<IActionResult> PostTask(TaskDto task)
        {
            return Ok(await _service.Create(task));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTask([FromRoute]int taskId, [FromBody]TaskDto task)
        {
            return Ok(await _service.Update(taskId, task));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            return Ok(await _service.Delete(taskId));
        }
    }
}
