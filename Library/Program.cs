
using Library.Controllers;
using Library.Interfaces;
using Library.Models;
using Library.Models.Books;
using Library.Models.Categories;
using Library.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Text;

public class program
{
    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection()
            .AddSingleton<BooleanConverter>()
            .AddDbContext<ApplicationDbContext>()
            .AddScoped<IBookRepository, EfBookCategory>()
            .AddScoped<ICategoryRepository, EfCategoryRepository>()
            .AddScoped<CategoryController>()
            .AddScoped<BookController>()
            .BuildServiceProvider();

        var categoryController = serviceCollection.GetRequiredService<CategoryController>();
        var bookController = serviceCollection.GetRequiredService<BookController>();

        StringBuilder menu = new();
        menu.AppendLine("1)Add Category");
        menu.AppendLine("2)Category List");
        menu.AppendLine("3)Add Book");
        menu.AppendLine("4)Book List");
        menu.AppendLine("5)Get Category Info");

        for (; ; )
        {
            Console.WriteLine(menu);
            var item = Console.ReadLine();
            Console.Clear();

            switch (item)
            {
                case "1":
                    {
                        Console.WriteLine("Please enter category title");
                        var title = Console.ReadLine();
                        var catDto = new CreateCategoryDto
                        {
                            Title = title
                        };
                        categoryController.Create(catDto);
                        break;
                    }
                case "2":
                    {
                        var catList = categoryController.GetAll();
                        foreach (var cat in catList)
                        {
                            Console.WriteLine(cat);
                        }
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Please enter title");
                        var title = Console.ReadLine();
                        Console.WriteLine("Please enter author");
                        var author = Console.ReadLine();
                        Console.WriteLine("Please enter code");
                        var code = Console.ReadLine();
                        Console.WriteLine("Please enter category Id");
                        var catId =Convert.ToInt32(Console.ReadLine());
                        var book = new AddBookDto
                        {
                            Title = title,
                            Author = author,
                            CategoryId = catId,
                            Code = code
                        };
                        bookController.Add(book);
                        break;
                    }
                case "4":
                    {
                        var BookList = bookController.GetAll();
                        foreach (var book in BookList)
                        {
                            Console.WriteLine(book);
                        }
                        break;
                    }
                case "5":
                    {
                        Console.WriteLine("Please enter category id");
                        var catId = Convert.ToInt32(Console.ReadLine());
                        var cat = categoryController.GetInfo(catId);
                        Console.WriteLine(cat);
                        foreach (var book in cat.Books)
                        {
                            Console.WriteLine(book);
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
