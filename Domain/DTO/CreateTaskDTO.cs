using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CreateTaskDTO
    {
        private int id;

        public CreateTaskDTO(Guid id)
    {
        Id = id;
    }

        public CreateTaskDTO(int id)
        {
            this.id = id;
        }

        public Guid Id { get; set; }
    }
}
