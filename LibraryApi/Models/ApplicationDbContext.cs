using LibraryApi.Models.Books;
using LibraryApi.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books{ get; set; }
}
