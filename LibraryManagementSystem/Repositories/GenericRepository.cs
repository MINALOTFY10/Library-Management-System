using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    // The following GenericRepository class implements the IGenericRepository interface
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> table;

        // Constructor that injects the database context and initializes the DbSet
        public GenericRepository(ApplicationDbContext _context)
        {
            context = _context;
            table = _context.Set<T>();
        }

        // Adds a new entity of type T to the database
        public void Add(T entity)
        {
            table.Add(entity);
        }

        // Updates an existing entity of type T in the database
        public void Update(T entity)
        {
            table.Update(entity);
        }

        // Deletes an entity by integer ID
        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                table.Remove(entity);
            }
        }

        // Deletes an entity by string ID
        public void Delete(string id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                table.Remove(entity);
            }
        }

        // Retrieves an entity by integer ID
        public T GetById(int id)
        {
            var result = table.Find(id);
            return result ?? throw new InvalidOperationException("Entity not found");
        }

        // Retrieves an entity by string ID
        public T GetById(string? id)
        {
            return table.Find(id)!;
        }

        // Retrieves all entities of type T from the database
        public List<T> GetAll()
        {
            return [.. table];
        }

        // Saves changes made to the database context
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
