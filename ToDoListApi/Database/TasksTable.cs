using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApi.Database
{
    public class TasksTable
    {
        [Key]
        [Column("ID")]
        public int TaskId { get; set; }
        [Required]
        [Column("NAME")]
        public string Name { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [Required]
        [Column("TASK_DATE")]
        public DateTime TaskDate { get; set; }
        
        [Column("NOTIFICATION_DATE")]
        public DateTime? NotificationDate { get; set; }

    }
}
