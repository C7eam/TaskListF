using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries
{
    public static class GetTasksQueryExtensions
    {
        public static GetTaskDTO MapTo(this Entities.Task task)
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
