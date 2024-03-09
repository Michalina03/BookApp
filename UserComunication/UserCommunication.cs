using BookApp.Components.CsvReader;
using BookApp.Components.CsvReader.Extension;
using BookApp.Data;
using BookApp.Data.Entities;
using BookApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace BookApp.UserComunication
{
    public class UserCommunication : IUserCommunication
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly BookAppDbContext _bookAppDbContext;
        public UserCommunication(IRepository<Book> bookRepository, BookAppDbContext bookAppDbContext)
        {
            _bookRepository = bookRepository;
            _bookAppDbContext = bookAppDbContext;
            _bookAppDbContext.Database.EnsureCreated();
        }
        public void CommunicationWithUser()
        {

            Console.WriteLine("|========= WELCOME TO BOOKAPP =========|");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|     This program is your library     |");
            Console.WriteLine("|                                      |");


            while (true)
            {
                Console.WriteLine("|---------------- MENU ----------------|");
                Console.WriteLine("|                                      |");
                Console.WriteLine("|          1. Read all books           |");
                Console.WriteLine("|          2. Add a book               |");
                Console.WriteLine("|          3. Remove a book            |");
                Console.WriteLine("|          4. Edition a book           |");
                Console.WriteLine("|          5. Exiting the program      |");
                Console.WriteLine("|                                      |");
                Console.WriteLine("|--------------------------------------|");

                var choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        ReadAllBookFromDb();
                        break;

                    case "2":
                        AddBook();
                        break;

                    case "3":
                        RemoveBook();
                        break;

                    case "4":
                        EditionBook("73");
                        break;

                    case "5":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        public void ReadAllBookFromDb()
        {
            var bookRepository = _bookRepository.GetAll();
            foreach (var bookFromDb in bookRepository)
            {
                Console.WriteLine($"Title: {bookFromDb.Title}");
                Console.WriteLine($"Author: {bookFromDb.Author}");
                Console.WriteLine($"PublicationDate: {bookFromDb.PublicationDate}");
                Console.WriteLine($"Manufacturer: {bookFromDb.Manufacturer}");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        public void AddBook()
        {
            Console.WriteLine("Insert title");
            var title = Console.ReadLine();
            Console.WriteLine("Insert author");
            var author = Console.ReadLine();
            Console.WriteLine("Insert publication date");
            var publicationDate = Console.ReadLine();
            Console.WriteLine("Insert manufacturer");
            var manufacturer = Console.ReadLine();
            Book bookFromDb = new Book { Title = title, Author = author, PublicationDate = publicationDate, Manufacturer = manufacturer};

            _bookRepository.Add(bookFromDb);
            _bookRepository.Save();
        }
        public void RemoveBook()
        {
            Console.WriteLine("Insert game ID");
            var bookId = BookLogicExtension.ConvertStringToInteger(Console.ReadLine());
            Book bookRepository = _bookRepository.GetById(bookId);
            if (bookRepository != null)
            {
                _bookRepository.Remove(bookRepository);
                _bookRepository.Save();
                Console.WriteLine($"Game with Id: {bookId} removed");
            }
            else
            {
                throw new Exception("Id number does not exist!");
            }
        }

        public void EditionBook(string id)
        {
            var bookRepository = _bookRepository.GetById(BookLogicExtension.ConvertStringToInteger(id));
            Console.WriteLine("=========================================");
            Console.WriteLine("What would you like to change?");
            Console.WriteLine("\nA => Title\nB => Author\nC => Publication date\nD => Manufacturer");
            var input = Console.ReadLine().ToUpper();
            if (bookRepository != null)
            {
                switch (input)
                {
                    case "A":
                        Console.WriteLine("Insert new title");
                        var title = Console.ReadLine();
                        bookRepository.Title = title;
                        break;
                    case "B":
                        Console.WriteLine("Insert new author");
                        var author = Console.ReadLine();
                        bookRepository.Author = author;
                        break;
                    case "C":
                        Console.WriteLine("Insert new publication date");
                        var publicationDate = Console.ReadLine();
                        bookRepository.PublicationDate = publicationDate;
                        break;
                    case "D":
                        Console.WriteLine("Insert new manofacturer");
                        var manufacturer = Console.ReadLine();
                        bookRepository.Manufacturer = manufacturer;
                        break;
                    default:
                        throw new Exception("Wrong letter!");
                }
            }
            Console.WriteLine($"Book with Id: {id} updated");
            _bookRepository.Save();
        }
    }
}
