﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class GetTaskDTO
    {
        public Guid Id { get; set; }
        [Required, StringLength(250)]
        public string TaskDescription { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? DateEnding { get; set; }

        public DateTime? DateDone { get; set; }

        public bool? IsDone { get; set; }
    }
}
