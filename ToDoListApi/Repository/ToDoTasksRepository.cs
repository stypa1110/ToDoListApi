
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Database;

namespace ToDoListApi.Repository
{
    public class ToDoTasksRepository : IToDoTasksRepository
    {
        private readonly ToDoListContext _context;

        public ToDoTasksRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewTask(string taskName, string taskDescription, DateTime taskDate, DateTime? notificationDate)
        {
            var newTask = new TasksTable
            {
                Name = taskName,
                Description = taskDescription,
                TaskDate = taskDate,
                NotificationDate = notificationDate,
            };

            try
            {
                await _context.ToDoTasks.AddAsync(newTask);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error when adding task to list " + ex.Message, ex);
            }
            
        }

        public async Task<bool> DeleteTask(int id)
        {
            try
            {
                var task = await _context.ToDoTasks.FirstOrDefaultAsync(f => f.TaskId == id);
                _context.ToDoTasks.Remove(task);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error when deleting task from list " + ex.Message, ex);
            }
            


        }

        public async Task<bool> EditTask(int id, string taskName, string taskDescription, DateTime taskDate, DateTime? notificationDate)
        {
            try
            {
                var task = await _context.ToDoTasks.FirstOrDefaultAsync(f => f.TaskId == id);
                task.Name = taskName;
                task.Description = taskDescription;
                task.TaskDate = taskDate;
                task.NotificationDate = notificationDate;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error when editing task " + ex.Message, ex);   
            }

        }

        public async Task<List<TasksTable>> GetTasksByDate(DateTime date)
        {
            return await _context.ToDoTasks.Where(w => w.TaskDate.Date == date.Date).ToListAsync();
        }
    }
}
