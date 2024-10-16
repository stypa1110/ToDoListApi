namespace ToDoListApi.Requests
{
    public class EditTaskCommand
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDate { get; set; }
        public DateTime? NotificationDate { get; set; }
    }
}
