using BookApp.Components.CsvReader;
using BookApp.UserComunication;

namespace BookApp
{
    public class App : IApp
    {
        private readonly IUserCommunication _userCommunication;
        private readonly ICsvReader _csvReader;

        public App(IUserCommunication userCommunication, ICsvReader csvReader)
        {
            _userCommunication = userCommunication;
            _csvReader = csvReader;
        }

        public void Run()
        {
            //_userCommunication.CommunicationWithUser();
            var bookmarks = _csvReader.ProcesseBookmark("Resources\\File\\fuel.csv");
            var manufacurer = _csvReader.ProcesseManufacturers("Resources\\File\\manufacturers.csv");

            var groups = bookmarks.GroupBy(x => x.Color).Select(g => new
            {
                Name = g.Key,
                Max = g.Max(c => c.Width)
            })
                .OrderBy(x => x.Max);

            foreach (var group in groups)
            {
                Console.WriteLine(group.Name);
                Console.WriteLine(group.Max);
            }
        }
    }
}
