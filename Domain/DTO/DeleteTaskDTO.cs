using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class DeleteTaskDTO
    {
        public DeleteTaskDTO(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
