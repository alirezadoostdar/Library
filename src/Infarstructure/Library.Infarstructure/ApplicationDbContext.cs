using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infarstructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Category> Categories{ get; set; }
    public DbSet<Book> Books{ get; set; }
}
