using Microsoft.EntityFrameworkCore;

namespace ToDoListApi.Database
{
    public class ToDoListContext : DbContext
    {
        public DbSet<TasksTable> ToDoTasks { get; set; }

        public string DbPath { get; }

        public ToDoListContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "todolist.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
