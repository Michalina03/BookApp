using BookApp.Data;
using BookApp.Entities;
using BookApp.Repositories;
using BookApp.Repositories.Extension;


var bookRepository = new SqlRepository<Book>(new BookAppDbContext());

AddBook(bookRepository);
WriteAllToConsole(bookRepository);

static void AddBook(IRepository<Book> bookRepository)
{
    var books = new[]
    {
        new Book { Title = "Ala" },
        new Book { Title = "Lena" },
        new Book { Title = "asia" }
    };
    bookRepository.AddBatch(books);
    "string".AddBatch(books);

    //AddBatch(bookRepository, books);

    //bookRepository.Add(new Book { Title = "Ala" });
    //bookRepository.Add(new Book { Title = "Lena" });
    //bookRepository.Add(new Book { Title = "Natalia" });
    //bookRepository.Save();
}


static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }

}