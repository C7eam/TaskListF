using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskListF.Controllers
{
    [Route("api/Task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TaskController> _logger;

        public TaskController(IMediator mediator, ILogger<TaskController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetTaskAsync(Guid id)
        {
            var task = await _mediator.Send(new GetTaskQuery(id));

            if (task != null)
            {
                return Ok(task);
            }

            return NotFound($"No task in database with ID: {id}.");

        }
    }
}
