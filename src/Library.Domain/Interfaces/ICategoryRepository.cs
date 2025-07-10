using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(int id);
    Task<Category> AddAsync(Category category);
    Task<Category> UpdateAsync(Category category);
    Task DeleteAsync(int id);
    Task<IEnumerable<Category>> GetAllAsync();

}
