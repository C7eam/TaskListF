using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;

namespace Domain
{

    public class GetTaskQuery : IRequest<GetTaskDTO>
    {
        public GetTaskQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}