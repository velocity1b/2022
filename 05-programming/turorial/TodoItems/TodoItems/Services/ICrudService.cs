namespace TodoItems.Services
{
    public interface ICrudService<T, U>
    {
        // CRUD
        public IEnumerable<T> GetAll();
        public T Get(U id);
        public void Add(T element);
        public void Update(T oldElement, T newElement);
        public void Delete(U id);
    }
}
