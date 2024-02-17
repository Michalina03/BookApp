using BookApp.Data.Entities;
using BookApp.Data.Repositories;

namespace BookApp.UserComunication
{
    public class UserCommunication : IUserCommunication
    {
        private readonly IRepository<Book> _bookRepository ;
        private readonly IRepository<Bookmark> _bookmarksRepository;
        public UserCommunication(IRepository<Book> bookRepository,
            IRepository<Bookmark> bookmarksRepository)
        {
            _bookRepository = bookRepository;
            _bookmarksRepository = bookmarksRepository;
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
                        Display();
                        break;

                    case "2":
                        AddNewBook();
                        bookRepository.Save();
                        break;

                    case "3":
                        RemoveBook();
                        bookRepository.Save();
                        break;

                    case "4":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void Display()
        {
            var repository = _bookRepository;
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

        private void AddNewBook()
        {
            while (true)
            {
                var bookRepository = _bookRepository;
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

        private void RemoveBook()
        {
            var bookRepository = _bookRepository;
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
    }
}
