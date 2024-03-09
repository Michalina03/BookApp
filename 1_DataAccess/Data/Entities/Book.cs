using System.Text;
namespace BookApp.Data.Entities
{
    public class Book : EntityBase
    {
        public string Title {get;set;}
        public string Author { get; set; }
        public string PublicationDate { get; set; }
        public string Manufacturer { get; set; }
    }
}