using BookApp.Entities;

namespace BookApp.Repositories.Extension
{
    public static class ExtensionRepository
    {
        public static void AddBatch<T>(this IRepository<T> repository, T[] items)
             where T : class, IEntity
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }

    }
}
