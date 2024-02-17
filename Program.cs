using BookApp;
using BookApp.Components.CsvReader;
using BookApp.Data;
using BookApp.Data.Entities;
using BookApp.Data.Repositories;
using BookApp.UserComunication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Book>, JsonRepository<Book>>();
services.AddSingleton<IRepository<Bookmark>, JsonRepository<Bookmark>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddDbContext<BookAppDbContext>(options => options.UseSqlServer("Data Source = DESKTOP-PQLADNG\\SQLEXPRESS01; Initial Catalog = BookAppStorage; Integrated Security = True"));
//Data Source=DESKTOP-PQLADNG\SQLEXPRESS01;Initial Catalog=TestStorage;Integrated Security=True

var servicesProvider = services.BuildServiceProvider();

var app = servicesProvider.GetService<IApp>();
app.Run();