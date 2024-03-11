using MediatR;

namespace TaskListF.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest<string>
    {
        public DeleteTaskCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
