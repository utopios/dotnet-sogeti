using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CorrectionTodoLists.Models
{
    [Table("todo_item")]
    public class ToDoItem
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("task_name")]
        public string TaskName { get; set; }

        [Column("done")]
        public bool Done { get; set; }

        [Column("todolist_id")]
        public int ToDoListId { get; set; }


        [ForeignKey("ToDoListId")]
        [JsonIgnore]
        public ToDoList? ToDoList { get; set; }
    }
}
