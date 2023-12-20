using BookApp.Entities;

namespace BookApp.Repositories.Extension
{
    public static class ExtensionRepository
    {
        public static void AddBatch<T>(this IRepository<T> repository, T[] items)
             where T : class, IEntity
        {
            foreach (var book in items)
            {
                repository.Add(book);
            }
            repository.Save();
        }

        public static void AddBatch<T>(this string s, T[] items)
            where T : class, IEntity
        {
            //s
        }
    }
}
