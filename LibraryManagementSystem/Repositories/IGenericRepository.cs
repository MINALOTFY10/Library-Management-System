namespace LibraryManagementSystem.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(string id);
        T GetById(int id);
        T GetById(string? id);
        List<T> GetAll();
        void Save();
    }
}
