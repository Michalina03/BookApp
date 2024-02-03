using BookApp.Components.CsvReader.Extension;
using BookApp.Components.CsvReader.Models;
namespace BookApp.Components.CsvReader
{
    public class CsvReader : ICsvReader
    {
        public List<Bookmark> ProcesseBookmark(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Bookmark>();
            }
            var bookmarks = File.ReadAllLines(filePath)
                .Skip(1)
                .Where(x => x.Length > 1)
                .ToBookmark();

            return bookmarks.ToList();
        }
        public List<Manufacturer> ProcesseManufacturers(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Manufacturer>();
            }
            var manufacturer = File.ReadAllLines(filePath)
                .Where(x => x.Length > 1)
                .Select(x =>
                {
                    var columns = x.Split(',');

                    return new Manufacturer()
                    {
                        Color = columns[0],
                        Height = int.Parse(columns[1]),
                        Width = int.Parse(columns[2]),
                        Shop = columns[3]
                    };
                });
            return manufacturer.ToList();
        }
    }
}
