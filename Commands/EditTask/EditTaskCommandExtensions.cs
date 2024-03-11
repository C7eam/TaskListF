using Task = Domain.Entities.Task;

namespace TaskListF.Commands.EditTask
{
    public static class EditTaskCommandExtensions
    {
        public static Task EditTask(this EditTaskCommand command)
        {
            var task = new Task
                (
            command.TaskDescription,
            command.DateEnding,
            command.DateDone,
            command.IsDone
                );

            return task;
        }
    }
}
