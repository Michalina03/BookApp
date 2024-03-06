using BookApp.Components.CsvReader.Models;

namespace BookApp.Components.CsvReader
{
    public interface ICsvReader
    {
        public List<Book> ProcesseBook(string filePath);
    }
}
