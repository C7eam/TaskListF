﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Task
    {
        public Task(string taskDescription, DateTime? dateEnding)
        {
            TaskDescription = taskDescription;
            DateEnding = dateEnding;
        }

        public Task(string taskDescription, DateTime dateEnding, DateTime? dateDone, bool isDone)
        {
            TaskDescription = taskDescription;
            DateEnding = dateEnding;
            DateDone = dateDone;
            IsDone = isDone;
        }

        public Guid Id { get; set; }

        [Required, StringLength(250)]
        public string TaskDescription { get; set; }

        [Required]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public DateTime? DateEnding { get; set; }

        public DateTime? DateDone { get; set; }

        public bool? IsDone { get; set; } = false;
    }
}