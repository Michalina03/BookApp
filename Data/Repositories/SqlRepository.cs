using BookApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {

        private readonly BookAppDbContext _bookAppDbContext;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(BookAppDbContext bookAppDbContext)
        {
            _bookAppDbContext = bookAppDbContext;
            _dbSet = bookAppDbContext.Set<T>();
        }

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemove;

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            _bookAppDbContext.SaveChanges();
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            _bookAppDbContext.SaveChanges();
            ItemRemove?.Invoke(this, item);
        }

        public void Save()
        {
            _bookAppDbContext.SaveChanges();
        }
        public IEnumerable<T> Read()
        {
            return _dbSet.ToList();
        }

        public int GetListCount()
        {
            return Read().ToList().Count;
        }
    }
}
