
using Library.Interfaces;
using Library.Models;
using Library.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories;

public class EfCategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public EfCategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Category category)
    {
        _context.Categories.Add(category);  
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetAll()
    {
        return _context.Categories;
    }

    public Category GetById(int id)
    {
        throw new NotImplementedException();
    }

    public bool IsDupplicat(string title)
    {
        return _context.Categories.Any(c => c.Title == title);
    }

    public void Update(Category category)
    {
        throw new NotImplementedException();
    }
}
