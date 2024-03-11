using Domain;
using Domain.DTO;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskListF.Commands;
using TaskListF.Commands.CreateTask;
using TaskListF.Commands.DeleteTask;
using TaskListF.Commands.EditTask;
using TaskListF.Requests;

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

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskRequest request)
        {
            var task = await _mediator.Send(new CreateTaskCommand(
            request.TaskDescription,
            request.DateEnding
            ));

            return Ok(task);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteTaskAsync(DeleteTaskDTO request)
        {
            await _mediator.Send(new DeleteTaskCommand(request.Id));

            return Ok();
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> EditTaskAsync([FromBody] EditTaskRequest request, Guid id)
        {
            var task = await _mediator.Send(new EditTaskCommand(
            id,
            request.TaskDescription,
            request.DateEnding,
            request.DateDone,
            request.IsDone));
            return Ok(task);
        }

        [HttpGet]
        public async Task<IActionResult> GetTasksAsync(Guid id)
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
