using BookApp.Components.CsvReader;
using BookApp.Components.DataProviders;
using BookApp.Data.Entities;
using BookApp.Data.Repositories;
using BookApp.UserComunication;
using Microsoft.Extensions.DependencyInjection;
using BookApp;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Book>, JsonRepository<Book>>();
services.AddSingleton<IRepository<Bookmark>, JsonRepository<Bookmark>>();
services.AddSingleton<IBookmarksProvider, BookmarksProvider>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<ICsvReader, CsvReader>();

var servicesProvider = services.BuildServiceProvider();

var app = servicesProvider.GetService<IApp>();
app.Run();