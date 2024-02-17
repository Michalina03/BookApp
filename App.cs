using BookApp.Components.CsvReader;
using BookApp.Data;
using BookApp.UserComunication;
using BookApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using BookApp.Components.CsvReader.Models;
using Bookmark = BookApp.Data.Entities.Bookmark;

namespace BookApp
{
    public class App : IApp
    {
        private readonly IUserCommunication _userCommunication;
        private readonly ICsvReader _csvReader;
        private readonly BookAppDbContext _bookAppDbContext;

        public App(IUserCommunication userCommunication, ICsvReader csvReader, BookAppDbContext bookAppDbContext)
        {
            _userCommunication = userCommunication;
            _csvReader = csvReader;
            _bookAppDbContext = bookAppDbContext;
            _bookAppDbContext.Database.EnsureCreated();
        }

        public void Run()
        {
            //_userCommunication.CommunicationWithUser();
            //InsertData();
            //ReadAllBookmarksFromDb();
            ReadGroupBookmarksFromDb();
        }

        private void ReadGroupBookmarksFromDb()
        {
            var groups = _bookAppDbContext
                .Bookmarks
                .GroupBy(x => x.Manufacturer)
                .Select(x => new
                {
                    Color = x.Key,
                    Bookmarks = x.ToList()
                })
                .ToList();

            foreach (var group in groups)
            {
                Console.WriteLine(group.Color);
                Console.WriteLine("=================");
                foreach(var bookmark in group.Bookmarks)
                {
                    Console.WriteLine($"Bookmark color: {bookmark.Color}");
                    Console.WriteLine($"Bookmark id: {bookmark.Id}");
                }
                Console.WriteLine();
            }
        }
        private void ReadAllBookmarksFromDb()
        {
            var carsFromDb = _bookAppDbContext.Bookmarks.ToList();
            foreach (var carFromDb in carsFromDb)
            {
                Console.WriteLine($"{carFromDb.Manufacturer} : {carFromDb.Id}");
            }
        }
        private void InsertData()
        {
            var bookmarks = _csvReader.ProcesseBookmark("Resources\\File\\fuel.csv");

            foreach (var bookmark in bookmarks)
            {
                _bookAppDbContext.Bookmarks.Add(new Bookmark()
                {
                    Color = bookmark.Color,
                    Height = bookmark.Height,
                    Manufacturer = bookmark.Manufacturer,
                    Width = bookmark.Width

                });
            }
            _bookAppDbContext.SaveChanges();
        }
    }
}
