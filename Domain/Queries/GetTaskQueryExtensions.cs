using Domain.DTO;
using Domain.Entities;

namespace Domain.Queries
{
    public static class GetTaskQueryExtensions
    {
        public static GetTaskDTO MapTo(this Domain.Entities.Task task)
        {
            return new GetTaskDTO
            {
                Id = task.Id,
                TaskDescription = task.TaskDescription,
                DateAdded = task.DateAdded,
                DateEnding = task.DateEnding,
                DateDone = task.DateDone,
                IsDone = task.IsDone
            };
        }
    }
}
