using TodoItems.Data.Repositories;
using TodoItems.Models;

namespace TodoItems.Services
{
    public class TodoService : ICrudService<TodoItem, int>
    {
        private readonly ICrudRepository<TodoItem, int> _todoRepository;
        public TodoService(ICrudRepository<TodoItem, int> todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public void Add(TodoItem element)
        {
            _todoRepository.Add(element);
            _todoRepository.Save();
        }
        public void Delete(int id)
        {
            _todoRepository.Delete(id);
            _todoRepository.Save();
        }
        public TodoItem Get(int id)
        {
            return _todoRepository.Get(id);
        }
        public IEnumerable<TodoItem> GetAll()
        {
            return _todoRepository.GetAll();
        }
        public void Update(TodoItem old, TodoItem newT)
        {
            old.Description = newT.Description;
            old.Status = newT.Status;
            _todoRepository.Update(old);
            _todoRepository.Save();
        }
    }

}
