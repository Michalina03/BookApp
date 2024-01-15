using BookApp.Repositories;
using BookApp.Entities;
using BookApp.DataProviders;

namespace BookApp
{
    public class App : IApp
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Bookmark> _bookmarksRepository;
        private readonly IBookmarksProvider _bookmarksProvider;
        public App(IRepository<Book> bookRepository,
            IRepository<Bookmark> bookmarksRepository,
            IBookmarksProvider bookmarksProvider)
        {
            _bookRepository = bookRepository;
            _bookmarksRepository = bookmarksRepository;
            _bookmarksProvider = bookmarksProvider;
        }
        public void Run()
        {
            Console.WriteLine("I'm here");
            var items = _bookRepository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);

            }


            var bookmarks = GenerateSampleBookmarks();
            foreach (var item in bookmarks)
            {
                _bookmarksRepository.Add(item);
            }

            foreach(var item in _bookmarksProvider.WhereColorIs("Purple"))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(_bookmarksProvider.GetMinimumPriceOfAllBookmarks());
            foreach (var item in _bookmarksProvider.OrderByName())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(_bookmarksProvider.AnonymusClass());
        }
        public static List<Bookmark> GenerateSampleBookmarks()
        {
            return new List<Bookmark>
            {
                new Bookmark
                {
                    Id = 1,
                    Name = "Bookmark_1",
                    Color = "Pink",
                    StandarCost = 23.99M,
                    ListPrice = 20.22M,
                    Dimension = "18cm"
                },
                new Bookmark
                {
                    Id = 2,
                    Name = "Bookmark_2",
                    Color = "Blue",
                    StandarCost = 26.79M,
                    ListPrice = 19.22M,
                    Dimension = "20cm"
                },
                new Bookmark
                {
                    Id = 3,
                    Name = "Bookmark_3",
                    Color = "White",
                    StandarCost = 31.89M,
                    ListPrice = 24.52M,
                    Dimension = "15cm"
                },
                new Bookmark
                {
                    Id = 4,
                    Name = "Bookmark_4",
                    Color = "Black",
                    StandarCost = 21.99M,
                    ListPrice = 24.52M,
                    Dimension = "22cm"
                },
                new Bookmark
                {
                    Id = 5,
                    Name = "Bookmark_5",
                    Color = "Green",
                    StandarCost = 17.90M,
                    ListPrice = 25.92M,
                    Dimension = "25cm"
                },
                new Bookmark
                {
                    Id = 6,
                    Name = "Bookmark_6",
                    Color = "Yelow",
                    StandarCost = 18.55M,
                    ListPrice = 15.78M,
                    Dimension = "15cm"
                },
                new Bookmark
                {
                    Id = 7,
                    Name = "Bookmark_7",
                    Color = "Purple",
                    StandarCost = 19.10M,
                    ListPrice = 21.92M,
                    Dimension = "19cm"
                }
            };
        }
    }
}
