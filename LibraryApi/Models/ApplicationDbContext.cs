using LibraryApi.Models.Agegroups;
using LibraryApi.Models.Books;
using LibraryApi.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new BookConfig());
        modelBuilder.ApplyConfiguration(new CategoryConfig());
        modelBuilder.ApplyConfiguration(new AgegroupConfig());
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books{ get; set; }
    public DbSet<Agegroup> Agegroups { get; set; }
}
