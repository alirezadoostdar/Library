using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Infarstructure.Repositories.Categories;

public class EfCategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public EfCategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Category> AddAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public Task<Category> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(category.Id);
    }
}
