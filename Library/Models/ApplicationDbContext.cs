using Library.Models.Books;
using Library.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-NPREDR7\\sql2019;Initial Catalog=Library;User ID=sa;Password=bastan.net.sqlserver;MultipleActiveResultSets=true;TrustServerCertificate=True;Trusted_Connection=True;");
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }
}
