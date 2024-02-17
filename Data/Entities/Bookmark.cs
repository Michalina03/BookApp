using System.Text;
namespace BookApp.Data.Entities
{
    public class Bookmark : EntityBase
    {
        public string Color {get;set;}
        public int Height { get; set; }
        public int Width { get; set; }
        public string Manufacturer { get; set; }
    }
}