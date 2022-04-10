using TodoItems.Models;

namespace TodoItems.Data.Repositories
{
    public class TodoRepository : ICrudRepository<TodoItem, int>
    {
        private readonly TodoContext _todoContext;
        public TodoRepository(TodoContext todoContext)
        {
            _todoContext = todoContext ?? throw new
            ArgumentNullException(nameof(todoContext));
        }
        public void Add(TodoItem element)
        {
            _todoContext.TodoItems.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _todoContext.TodoItems.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _todoContext.TodoItems.Any(u => u.Id == id);
        }
        public TodoItem Get(int id)
        {
            return _todoContext.TodoItems.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<TodoItem> GetAll()
        {
            return _todoContext.TodoItems.ToList();
        }
        public bool Save()
        {
            return _todoContext.SaveChanges() > 0;
        }
        public void Update(TodoItem element)
        {
            _todoContext.Update(element);
        }
    }

}
