
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

        var menu = "1)Add Category";

        for (; ; )
        {
            Console.WriteLine(menu);
            var item = Console.ReadLine();
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
                default:
                    break;
            }
        }
    }
}
