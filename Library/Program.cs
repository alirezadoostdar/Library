
using Library.Controllers;
using Library.Interfaces;
using Library.Models;
using Library.Models.Categories;
using Library.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

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
            .BuildServiceProvider();

        var categoryController = serviceCollection.GetRequiredService<CategoryController>();

        var menu = "1)Add Category 2)Category List";

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
                default:
                    break;
            }
        }
    }
}
