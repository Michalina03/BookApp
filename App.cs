using BookApp.Components.CsvReader;
using BookApp.Data;
using BookApp.UserComunication;
using Book = BookApp.Data.Entities.Book;

namespace BookApp
{
    public class App : IApp
    {
        private readonly IUserCommunication _userCommunication;

        public App(IUserCommunication userCommunication)
        {
            _userCommunication = userCommunication;
        }

        public void Run()
        {
            _userCommunication.CommunicationWithUser();
        }
    }
}
