﻿namespace TaskListF.Requests
{
    public class CreateTaskRequest
    {
        public string? TaskDescription { get; set; }

        public DateTime DateEnding { get; set; }
    }
}