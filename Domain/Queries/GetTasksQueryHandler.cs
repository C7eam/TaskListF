using Domain.Context;
using Domain.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Domain.Queries
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IList<Entities.Task>>
    {
        private readonly ApplicationContext _context;
        private readonly IDistributedCache _cache;

        public GetTasksQueryHandler(ApplicationContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IList<Entities.Task>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Task> tasks = null;
            List<Entities.Task> taskList = null;
            var tasksString = await _cache.GetStringAsync(request.ToString(), cancellationToken);
            if (tasksString != null) taskList = JsonSerializer.Deserialize<List<Entities.Task>>(tasksString);

            if (tasks == null)
            {
                tasks = await _context.Tasks.ToListAsync(cancellationToken);
                if (tasks != null)
                    foreach (Domain.Entities.Task taskItem in tasks)
                    {
                        var task = taskItem;
                        taskList.Add(task);
                    }
                else
                {
                    tasksString = JsonSerializer.Serialize(tasks);
                    await _cache.SetStringAsync(taskList.ToString(), tasksString, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                    }, cancellationToken);
                }
            }
            return taskList;
        }
    }
}
