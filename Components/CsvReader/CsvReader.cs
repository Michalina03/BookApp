using BookApp.Components.CsvReader.Extension;
using BookApp.Components.CsvReader.Models;
namespace BookApp.Components.CsvReader
{
    public class CsvReader : ICsvReader
    {
        public List<Book> ProcesseBook(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Book>();
            }
            var bookmarks = File.ReadAllLines(filePath)
                .Skip(1)
                .Where(x => x.Length > 1)
                .ToBookmark();

            return bookmarks.ToList();
        }
    }
}
