namespace ToDoListApi.Requests
{
    public class AddTaskCommand
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDate { get; set; }
        public DateTime? NotificationDate { get; set; }
    }
}
