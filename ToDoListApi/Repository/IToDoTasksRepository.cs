using ToDoListApi.Database;

namespace ToDoListApi.Repository
{
    public interface IToDoTasksRepository
    {
        public Task<bool> AddNewTask(string taskName, string taskDescription, DateTime taskDate, DateTime? notificationDate);
        public Task<List<TasksTable>> GetTasksByDate(DateTime date);
        public Task<bool> EditTask(int id, string taskName, string taskDescription, DateTime taskDate, DateTime? notificationDate);
        public Task<bool> DeleteTask(int id);
    }
}
