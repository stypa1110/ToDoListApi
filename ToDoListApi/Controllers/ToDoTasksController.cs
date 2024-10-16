using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Database;
using ToDoListApi.Repository;

namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoTasksController : ControllerBase
    {
        private readonly IToDoTasksRepository _toDoTasksRepository;

        public ToDoTasksController(IToDoTasksRepository toDoTasksRepository)
        {
            _toDoTasksRepository = toDoTasksRepository;
        }

        [HttpPost("addtask")]
        public async Task<bool> AddTask([FromBody] TasksTable command)
        {
            return await _toDoTasksRepository.AddNewTask(command.Name, command.Description, command.TaskDate, command.NotificationDate);
        }

        [HttpGet("gettasks")]
        public async Task<List<TasksTable>> GetTasks([FromQuery] DateTime date)
        {
            return await _toDoTasksRepository.GetTasksByDate(date);
        }

        [HttpPatch("edittask")]
        public async Task<bool> EditTask([FromBody] TasksTable command)
        {
            return await _toDoTasksRepository.EditTask(command.TaskId, command.Name, command.Description, command.TaskDate, command.NotificationDate);
        }

        [HttpDelete("deletetask")]
        public async Task<bool> DeleteTask([FromQuery] int taskId)
        {
            return await _toDoTasksRepository.DeleteTask(taskId);
        }
    }
}
