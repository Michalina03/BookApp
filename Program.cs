using BookApp.Entities;
using BookApp.Repositories;
class Program
{ 
    static void Main()
    {
        Console.WriteLine("Welcome to BookApp");
        Console.WriteLine("This program is your library");
        Console.WriteLine("----------------------------");
      
        var bookRepository = new JsonRepository<Book>();
        bookRepository.ItemAdded += BookRepositoryOnItemAdded;
        bookRepository.ItemRemoved += BookRepositoryOnItemRemoved;

        while (true)
        {
            Menu();
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
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void Menu()
    {
        Console.WriteLine("-------- MENU ---------");
        Console.WriteLine("1. to display a book");
        Console.WriteLine("2. to add a book");
        Console.WriteLine("3. to remove a books");
        Console.WriteLine("4. exit the program");
    }

    static void BookRepositoryOnItemAdded(object? sender, Book e)
    {
        Console.WriteLine($" Book with ID {e.Id} From: {sender?.GetType().Name} Data: {DateTime.Now}, Book added => {e.Title}");
    }

    static void BookRepositoryOnItemRemoved(object? sender, Book e)
    {
        Console.WriteLine($"Book with ID {e.Id}  From: {sender?.GetType().Name} Data: {DateTime.Now},  Book to remove => {e.Title}");
    }


    static void Display(IReadRepository<IEntity> repository)
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
}