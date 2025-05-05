
using Library.Interfaces;
using Library.Models;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

public class program
{
    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection()
            .AddSingleton<BooleanConverter>()
            .AddDbContext<ApplicationDbContext>()
            .AddScoped<IBookRepository,>
    }
}
