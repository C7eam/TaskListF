using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entities;

namespace Domain.Queries;


public class GetTaskQuery : IRequest<Entities.Task>
{
    public GetTaskQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}