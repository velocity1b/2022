namespace TodoItems.Data.Repositories
{
    public interface ICrudRepository<T, U>
    {
        // CRUD
        public IEnumerable<T> GetAll();
        public T Get(U id);
        public void Add(T element);
        public void Update(T element);
        public void Delete(U id);

        // Extra
        public bool Exists(U id);
        public bool Save();
    }

}
