using BookApp.DataProviders;
using BookApp.Entities;
using BookApp.Repositories;

namespace BookApp.UserComunication
{
    public class UserCommunication : IUserCommunication
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Bookmark> _bookmarksRepository;
        private readonly IBookmarksProvider _bookmarksProvider;
        public UserCommunication(IRepository<Book> bookRepository,
            IRepository<Bookmark> bookmarksRepository,
            IBookmarksProvider bookmarksProvider)
        {
            _bookRepository = bookRepository;
            _bookmarksRepository = bookmarksRepository;
            _bookmarksProvider = bookmarksProvider;
        }
        public void CommunicationWithUser()
        {

            Console.WriteLine("Welcome to BookApp");
            Console.WriteLine("This program is your library");
            Console.WriteLine("----------------------------");

            var bookRepository = new JsonRepository<Book>();


            while (true)
            {
                Console.WriteLine("-------- MENU ---------");
                Console.WriteLine("1. to display a books");
                Console.WriteLine("2. to add a book");
                Console.WriteLine("3. to remove a books");
                Console.WriteLine("4. to display bookmarks");
                Console.WriteLine("5. to run metods bookmarks");
                Console.WriteLine("6. exiting the program");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Display(bookRepository);
                        break;

                    case "2":
                        AddNewBook(bookRepository);
                        bookRepository.Save();
                        break;

                    case "3":
                        RemoveBook(bookRepository);
                        bookRepository.Save();
                        break;
                    case "4":
                        BookmarksDisplay();
                        break;

                    case "5":
                        BookmarksMetod();
                        break;

                    case "6":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void Display(IReadRepository<IEntity> repository)
        {
            Console.WriteLine("----- CATALOG -----");
            var items = repository.GetAll();
            if (items.ToList().Count == 0)
            {
                Console.WriteLine("No objects found!");
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        static void AddNewBook(IRepository<Book> bookRepository)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    bookRepository.Add(new Book { Title = input });
                    bookRepository.Save();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception catch {e.Message}");
                }
            }

        }

        static void RemoveBook(IRepository<Book> bookRepository)
        {
            Console.Write("Enter the ID of the book to remove: ");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                var bookToRemove = bookRepository.GetById(bookId);

                if (bookToRemove != null)
                    bookRepository.Remove(bookToRemove);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
            }
        }
        private void BookmarksDisplay()
        {
            var bookmarks = GenerateSampleBookmarks();
            foreach (var item in bookmarks)
            {
                _bookmarksRepository.Add(item);
            }
            Console.WriteLine(_bookmarksProvider.AnonymusClass());
        }

        private void BookmarksMetod()
        {
            var bookmarks = GenerateSampleBookmarks();
            foreach (var item in bookmarks)
            {
                _bookmarksRepository.Add(item);
            }
            Console.WriteLine("====== Bookmarks metod: OrderByName ======");
            foreach (var item in _bookmarksProvider.OrderByName())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("====== Bookmarks metod: DistincAllColor ======");
            foreach (var item in _bookmarksProvider.DistincAllColor())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("====== Bookmarks metod: GetSpecificColumns ======");
            foreach (var item in _bookmarksProvider.GetSpecificColumns())
            {
                Console.WriteLine(item);
            }
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
                    ListPrice = 19.10M,
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
