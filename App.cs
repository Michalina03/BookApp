using BookApp.Components.CsvReader;
using BookApp.UserComunication;
using System.Xml.Linq;

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
            _userCommunication.CommunicationWithUser();
            CreateXmlFuel();
            QertyXmlFuel();
            CreateXmlManufacturers();
            QertyXmlManufactuers();
            GroupJoin();
        }

        private void CreateXmlFuel()
        {
            var records = _csvReader.ProcesseBookmark("Resources\\File\\fuel.csv");

            var document = new XDocument();
            var bookmarks = new XElement("Bookmarks", records
                .Select(x => new XElement("Bookmark",
                new XAttribute("Color", x.Color),
                new XAttribute("Height", x.Height),
                new XAttribute("Width", x.Width),
                new XAttribute("Manufactrurer", x.Manufacturer))));

            document.Add(bookmarks);
            document.Save("fuel.xml");
        }

        private void QertyXmlFuel()
        {
            var document = XDocument.Load("fuel.xml");

            var names = document
                .Element("Bookmarks")?
                .Elements("Bookmark");

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private void CreateXmlManufacturers()
        {
            var records = _csvReader.ProcesseManufacturers("Resources\\File\\manufacturers.csv");

            var document = new XDocument();
            var bookmarks = new XElement("Bookmarks", records
                .Select(x => new XElement("Bookmark",
            new XAttribute("Color", x.Color),
                new XAttribute("Height", x.Height),
                new XAttribute("Width", x.Width),
                new XAttribute("Number", x.Number),
                new XAttribute("Manufactrurer", x.Shop))));

            document.Add(bookmarks);
            document.Save("manufacturer.xml");
        }

        private void QertyXmlManufactuers()
        {
            var document = XDocument.Load("manufacturer.xml");

            var names = document
                .Element("Bookmarks")?
                .Elements("Bookmark");

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private void GroupJoin()
        {
            var bookmarks = _csvReader.ProcesseBookmark("Resources\\File\\fuel.csv");
            var manufacturers = _csvReader.ProcesseManufacturers("Resources\\File\\manufacturers.csv");

            var groups = manufacturers.GroupJoin(
                bookmarks,
                manufacturers => manufacturers.Color,
                bookmarks => bookmarks.Manufacturer,
                (m, b) =>
                new
                {
                    Manufacturer = m,
                    Bookmarks = b
                }).OrderBy(x => x.Manufacturer.Color);

            foreach (var bookmark in groups)
            {
                Console.WriteLine($"Manufacturer: {bookmark.Manufacturer.Height}");
                Console.WriteLine($"Count: {bookmark.Bookmarks.Count()}");
            }
        }
    }
}
