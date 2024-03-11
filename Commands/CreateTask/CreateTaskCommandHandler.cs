using Domain.Context;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace TaskListF.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskDTO>
    {
        private readonly ApplicationContext _applicationContext;

        public CreateTaskCommandHandler(ApplicationContext applicationContext)
        {
            this._applicationContext = applicationContext;
        }

        public async Task<CreateTaskDTO> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = request.CreateTask();
            await _applicationContext.Tasks.AddAsync(task, cancellationToken);
            await _applicationContext.SaveChangesAsync(cancellationToken);

            return new CreateTaskDTO(task.Id);
        }
    }
}
