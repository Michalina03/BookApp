using BookApp.DataProviders.Extension;
using BookApp.Entities;
using BookApp.Repositories;
using System.Text;
namespace BookApp.DataProviders
{
    public class BookmarksProvider : IBookmarksProvider
    {
        private readonly IRepository<Bookmark> _bookmarksRepository;
        public BookmarksProvider(IRepository<Bookmark> bookmarksRepository)
        {

            _bookmarksRepository = bookmarksRepository;
        }
        public string AnonymusClass()
        {
            var bookmarks = _bookmarksRepository.GetAll();
            var list = bookmarks.Select(bookmark => new
            {
                Identifier = bookmark.Id,
                ProductName = bookmark.Name,
                ProductDimension = bookmark.Dimension,
                StandarCosts = bookmark.StandarCost,
                Colors = bookmark.Color,
                ListPrices = bookmark.ListPrice
            });
            StringBuilder sb = new(2048);
            foreach (var bookmark in list)
            {
                sb.AppendLine($"Product ID: {bookmark.Identifier}");
                sb.AppendLine($"Product Name: {bookmark.ProductName}");
                sb.AppendLine($"Product Dimension: {bookmark.ProductDimension}");
                sb.AppendLine($"Product Color: {bookmark.Colors}");
                sb.AppendLine($"Product StandarCost: {bookmark.StandarCosts}");
                sb.AppendLine($"Product ListPrice: {bookmark.ListPrices}");
                sb.AppendLine($"=============================================");
            }
            return sb.ToString();
        }


        public decimal GetMinimumPriceOfAllBookmarks()
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.Select(x => x.ListPrice).Min();
        }

        public List<Bookmark> GetSpecificColumns()
        {
            var bookmarks = _bookmarksRepository.GetAll();
            var list = bookmarks.Select(bookmark => new Bookmark
            {
                Id = bookmark.Id,
                Name = bookmark.Name,
                Dimension = bookmark.Dimension
            }).ToList();
            return list;
        }

        public List<string> GetUniqueBookmarksColor()
        {
            var bookmarks = _bookmarksRepository.GetAll();
            var colors = bookmarks.Select(x => x.Color).Distinct().ToList();
            return colors;
        }


        public List<Bookmark> OrderByColorAndName()
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks
                .OrderBy(x => x.Color)
                .ThenBy(x => x.Name).ToList();
        }

        public List<Bookmark> OrderByColorAndNameDesc()
        {

            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks
                .OrderByDescending(x => x.Color)
                .ThenByDescending(x => x.Name).ToList();
        }

        public List<Bookmark> OrderByName()
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.OrderBy(x => x.Name).ToList();
        }

        public List<Bookmark> OrderByNameDescending()
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.OrderByDescending(x => x.Name).ToList();
        }

        public List<Bookmark> WhereColorIs(string color)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.ByColor("Red").ToList();
        }

        public List<Bookmark> WhereStartsWith(string prefix)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.Where(x => x.Name.StartsWith(prefix)).ToList();
        }

        public List<Bookmark> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.Where(x => x.Name.StartsWith(prefix) && x.StandarCost > cost).ToList();
        }

        public Bookmark FirstByColor(string color)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.First(x => x.Color == color);
        }

        public Bookmark? FirstOrDefaultByColor(string color)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.FirstOrDefault(x => x.Color == color);
        }

        public Bookmark FirstOrDefaultByColorWithDefault(string color)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.FirstOrDefault(x => x.Color == color, new Bookmark { Id = -1, Name = "NOT FOUND" });
        }
        public Bookmark LastByColor(string color)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.Last(x => x.Color == color);
        }

        public Bookmark SingleById(int id)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.Single(x => x.Id == id);
        }

        public Bookmark SingleOrDefaultById(int id)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.SingleOrDefault(x => x.Id == id);
        }

        public List<Bookmark> TakeBookmarks(int howMony)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks
                .OrderBy(x => x.Name)
                .Take(howMony).ToList();
        }

        public List<Bookmark> TakeBookmarks(Range range)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks
                .OrderBy(x => x.Name)
                .Take(range).ToList();
        }

        public List<Bookmark> TakeBookmarksWhileNameStartsWith(string prefix)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks
                .OrderBy(x => x.Name)
                .TakeWhile(x => x.Name.StartsWith(prefix)).ToList();
        }

        public List<Bookmark> SkipBookmarks(int howMony)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks
                .OrderBy(x => x.Name)
                .Skip(howMony).ToList();
        }

        public List<Bookmark> SkipBookmarksWhileNameStartsWith(string prefix)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks
                .OrderBy(x => x.Name)
                .SkipWhile(x => x.Name.StartsWith(prefix)).ToList();
        }

        public List<string> DistincAllColor()
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks
                .Select(x => x.Color)
                .Distinct()
                .OrderBy(c => c)
                .ToList();
        }

        public List<Bookmark> DistincByColor()
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks
                .DistinctBy(x => x.Color)
                .OrderBy(x => x.Color)
                .ToList();
        }

        public List<Bookmark[]> ChunkBookmarks(int size)
        {
            var bookmarks = _bookmarksRepository.GetAll();
            return bookmarks.Chunk(size).ToList();
        }
    }
}
