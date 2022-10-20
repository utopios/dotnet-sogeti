using CorrectionTodoLists.Models;
using CorrectionTodoLists.Tools;
using System.Linq;

namespace CorrectionTodoLists.Repositories
{
    public class ToDoItemRepository : BaseRepository<ToDoItem>
    {
        private ToDoListRepository _toDoListRepository;
        public ToDoItemRepository(DataDbContext dataContext, ToDoListRepository toDoListRepository) : base(dataContext)
        {
            _toDoListRepository = toDoListRepository;
        }

        public override bool Delete(ToDoItem element)
        {
            throw new NotImplementedException();
        }

        public override List<ToDoItem> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> FindAll(int todoListId)
        {
            return _dataContext.ToDoItems.Where(t => t.ToDoListId == todoListId).ToList();
        }

        public override ToDoItem FindById(int id)
        {
            return _dataContext.ToDoItems.FirstOrDefault(t => t.Id == id);
        }

        public override bool Save(ToDoItem element)
        {
            throw new NotImplementedException();
        }
        public  bool Save(ToDoItem element, int id)
        {
            ToDoList toDolist = _toDoListRepository.FindById(id);
            if(toDolist != null)
            {
                
                toDolist.Items.Add(element);
                return _dataContext.SaveChanges() > 0;
            }
            return false;
        }
        public override List<ToDoItem> Search(Func<ToDoItem, bool> searchMethod)
        {
            return _dataContext.ToDoItems.Where(searchMethod).ToList();
        }
    }
}
