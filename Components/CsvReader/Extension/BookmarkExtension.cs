using BookApp.Components.CsvReader.Models;

namespace BookApp.Components.CsvReader.Extension
{
    public static class BookmarkExtension
    {
        public static IEnumerable<Bookmark> ToBookmark(this IEnumerable<string >source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Bookmark
                {
                    Color =columns[0],
                    Height = int.Parse(columns[1]),
                    Width = int.Parse(columns[2]),
                    Manufacturer = columns[3]
                };
            }
        }
    }
}
