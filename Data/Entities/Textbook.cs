namespace BookApp.Data.Entities
{
    public class Textbook : Book
    {
        public override string ToString() => base.ToString() + "(TextBook)";
    }
}
