using CorrectionTodoLists.Models;
using CorrectionTodoLists.Tools;
using Microsoft.EntityFrameworkCore;

namespace CorrectionTodoLists.Repositories
{
    public class ToDoListRepository : BaseRepository<ToDoList>
    {
        public ToDoListRepository(DataDbContext dataContext) : base(dataContext)
        {
        }

        public override bool Delete(ToDoList element)
        {
            throw new NotImplementedException();
        }

        public override List<ToDoList> FindAll()
        {
            return _dataContext.ToDoLists.Include(t => t.Items).ToList();
        }

        public override ToDoList FindById(int id)
        {
            return _dataContext.ToDoLists.Include(t => t.Items).FirstOrDefault(t => t.Id == id);
        }

        public override bool Save(ToDoList element)
        {
            _dataContext.ToDoLists.Add(element);
            return _dataContext.SaveChanges() > 0;
        }

        public override List<ToDoList> Search(Func<ToDoList, bool> searchMethod)
        {
            return _dataContext.ToDoLists.Include(t => t.Items).Where(searchMethod).ToList();
        }
    }
}
