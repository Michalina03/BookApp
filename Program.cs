using BookApp;
using BookApp.DataProviders;
using BookApp.Entities;
using BookApp.Repositories;
using BookApp.UserComunication;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Book>, JsonRepository<Book>>();
services.AddSingleton<IRepository<Bookmark>, JsonRepository<Bookmark>>();
services.AddSingleton<IBookmarksProvider, BookmarksProvider>();
services.AddSingleton<IUserCommunication, UserCommunication>();

var servicesProvider = services.BuildServiceProvider();

var app = servicesProvider.GetService<IApp>();
app.Run();