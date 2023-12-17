using BookApp.Entities;

namespace BookApp.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
    }
}
