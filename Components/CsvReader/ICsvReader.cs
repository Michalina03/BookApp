using BookApp.Components.CsvReader.Models;

namespace BookApp.Components.CsvReader
{
    public interface ICsvReader
    {
        public List<Bookmark> ProcesseBookmark(string filePath);
        public List<Manufacturer> ProcesseManufacturers(string filePath);
    }
}
