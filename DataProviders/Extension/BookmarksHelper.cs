using BookApp.Entities;
using System.Net.Http.Headers;

namespace BookApp.DataProviders.Extension
{
    public static class BookmarksHelper
    {
        public static IEnumerable<Bookmark> ByColor(this IEnumerable<Bookmark> query, string color)
        {
            return query.Where(x => x.Color == color);
        }
    }
}
