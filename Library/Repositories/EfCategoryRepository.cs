
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
        var cat = _context.Categories.Find(id);
        _context.Categories.Remove(cat);    
        _context.SaveChanges();
    }

    public IEnumerable<Category> GetAll()
    {
        var list =  _context.Categories;
        return list;
    }

    public Category GetById(int id)
    {
        var cat =  _context.Categories.Where(x => x.Id == id)
                    .Include(b => b.Books).FirstOrDefault();
        return cat;
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
