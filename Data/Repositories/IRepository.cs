using BookApp.Data.Entities;

namespace BookApp.Data.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
    }
}
