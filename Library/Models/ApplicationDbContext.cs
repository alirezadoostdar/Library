using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer();
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }
}
