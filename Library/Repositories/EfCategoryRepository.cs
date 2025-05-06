
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
        throw new NotImplementedException();
    }

    public Category GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Category category)
    {
        throw new NotImplementedException();
    }
}
