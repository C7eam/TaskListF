using Domain.DTO;
using MediatR;

namespace TaskListF.Commands.EditTask
{
    public class EditTaskCommand : IRequest<EditTaskDTO>
    {
        public EditTaskCommand()
        {
        }

        public EditTaskCommand(string taskDescription)
        {
            TaskDescription = taskDescription;
        }

        public EditTaskCommand(Guid id, string taskDescription,
            DateTime dateEnding,
            DateTime? dateDone,
            bool isDone)
        {
            Id = id;
            TaskDescription = taskDescription;
            DateEnding = dateEnding;
            DateDone = dateDone;
            IsDone = isDone;
        }
        public Guid Id { get; set; }
        public string TaskDescription { get; set; }

        public DateTime DateEnding { get; set; }

        public DateTime? DateDone { get; set; }

        public bool IsDone { get; set; } = false;
    }
}