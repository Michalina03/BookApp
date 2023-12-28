namespace BookApp.Entities
{
    public class Book : EntityBase
    {
        public string? Title { get; set; }

        public override string ToString() => $"Id: {Id} Title:{Title}";

    }
}
