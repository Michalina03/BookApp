using BookApp.Components.CsvReader.Models;
namespace BookApp.Components.CsvReader.Extension
{
    public static class BookExtension
    {
        public static IEnumerable<Book> ToBookmark(this IEnumerable<string >source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Book
                {
                    Title = columns[0],
                    Author = columns[1],
                    PublicationDate = columns[2],
                    Manufacturer = columns[3]
                };
            }
        }
    }
}
