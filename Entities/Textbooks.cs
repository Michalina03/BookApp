namespace BookApp.Entities
{
    public class Textbooks : Book
    {
        public override string ToString() => base.ToString() + "(TextBook)";
    }
}
