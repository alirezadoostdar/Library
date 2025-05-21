using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Models.Categories;

public interface ICategoryRepository
{
    void Add(Category category);
    List<GetCategoryDto> GetAll();
    Category? GetById(int id);
    void Update(Category category);
    void Remove(Category category);
}


public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public List<GetCategoryDto> GetAll()
    {
       return _context.Categories.Select(x => new GetCategoryDto
       {
           Id = x.Id,
           Title = x.Title,
       }).ToList();
    }

    public Category? GetById(int id)
    {
        return _context.Categories
            .Include(a => a.AgeGroup)
            .FirstOrDefault(c => c.Id == id);
    }

    public void Remove(Category category)
    {
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }

    public void Update(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }
}
