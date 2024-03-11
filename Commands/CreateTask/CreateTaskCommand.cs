using Domain.DTO;
using MediatR;

namespace TaskListF.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<CreateTaskDTO>
    {
        public CreateTaskCommand(string taskDescription, DateTime dateEnding)
        {
            TaskDescription = taskDescription;
            DateEnding = dateEnding;
        }

        public DateTime? DateAdded { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? DateEnding { get; set; }

        public DateTime? DateDone { get; set; }
        public bool IsDone { get; set; } = false;
    }
}
