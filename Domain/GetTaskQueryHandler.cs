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
using System.Threading.Tasks;

namespace Domain
{
    public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, GetTaskDTO>
    {
        private readonly ApplicationContext _context;
        private readonly IDistributedCache _cache;

        public GetTaskQueryHandler(ApplicationContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<GetTaskDTO> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Task? task = null;
            var taskString = await _cache.GetStringAsync(request.Id.ToString(), cancellationToken);
            if (taskString != null) task = JsonSerializer.Deserialize<Domain.Entities.Task>(taskString);

            if (task == null)
            {
                task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                if (task != null)
                {
                    taskString = JsonSerializer.Serialize(task);
                    await _cache.SetStringAsync(task.Id.ToString(), taskString, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                    }, cancellationToken);
                }
            }
            return task.MapTo();
        }
    }
}
