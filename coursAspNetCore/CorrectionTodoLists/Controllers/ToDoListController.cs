using CorrectionTodoLists.Models;
using CorrectionTodoLists.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CorrectionTodoLists.Controllers
{
    [ApiController]
    [Route("api/v1/todolists")]
    public class ToDoListController : ControllerBase
    {
        private ToDoListRepository _toDoListRepository;

        public ToDoListController(ToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public List<ToDoList> Get(string? title = null)
        {
            if (title == null)
                return _toDoListRepository.FindAll();
            else
                return _toDoListRepository.Search(t => t.Title.Contains(title));
        }

        [HttpGet("{id}")]
        public ToDoList Get(int id)
        {
            return _toDoListRepository.FindById(id);
        }

        [HttpPost]
        public ToDoList Save([FromBody] ToDoList toDoList)
        {
            if(_toDoListRepository.Save(toDoList))
            {
                return toDoList;
            }
            return null;
        }
        
    }
}
