using LibraryApi.Models.Agegroups;
using LibraryApi.Models.Authors;
using LibraryApi.Models.Books;
using LibraryApi.Models.Categories;
using LibraryApi.Models.Members;
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
        //modelBuilder.ApplyConfiguration(new BookConfig());
        //modelBuilder.ApplyConfiguration(new CategoryConfig());
        //modelBuilder.ApplyConfiguration(new AgeGroupConfig());
        //modelBuilder.ApplyConfiguration(new AuthorConfig());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books{ get; set; }
    public DbSet<AgeGroup> AgeGroups { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Member> Members { get; set; }
}
