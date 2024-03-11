namespace TaskListF.Requests
{
    public class EditTaskRequest
    {

        public string TaskDescription { get; set; }

        public DateTime DateEnding { get; set; }

        public DateTime? DateDone { get; set; }

        public bool IsDone { get; set; }
    }
}