using Task = Domain.Entities.Task;

namespace TaskListF.Commands.CreateTask
{
    public static class CreateTaskCommandExtensions
    {
        public static Task CreateTask(this CreateTaskCommand command)
        {
            var task = new Task
                (
                    command.TaskDescription,
                    command.DateEnding
                );

            return task;
        }
    }
}
