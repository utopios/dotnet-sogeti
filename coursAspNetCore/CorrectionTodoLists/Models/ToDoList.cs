using System.ComponentModel.DataAnnotations.Schema;

namespace CorrectionTodoLists.Models
{
    [Table("todo_list")]
    public class ToDoList
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }
        
        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("complete")]
        public bool Complete { get; set; }

        public List<ToDoItem> Items { get; set; }

        public ToDoList()
        {
            Items = new List<ToDoItem>();
        }
    }
}
