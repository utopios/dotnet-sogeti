using CorrectionTodoLists.Models;
using CorrectionTodoLists.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorrectionTodoLists.Controllers
{
    [Route("api/v1/todolists")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {

        private ToDoItemRepository _todoItemRepository;

        public TodoItemController(ToDoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        [HttpGet("{todolistId}/todoitems")]
        public List<ToDoItem> Get(int todolistId)
        {
            return _todoItemRepository.FindAll(todolistId);
        }

        [HttpPost("{todolistId}/todoitems")]
        public ToDoItem Post(int todolistId, [FromBody] ToDoItem toDoItem)
        {
            if (_todoItemRepository.Save(toDoItem, todolistId))
                return toDoItem;
            return null;
        }

        [HttpGet("{todolistId}/todoitems/{id}")]
        public ToDoItem Get(int todolistId, int id)
        {
            return _todoItemRepository.FindById(id);
        }
    }
}
