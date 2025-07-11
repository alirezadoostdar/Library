using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Infarstructure.Repositories.Categories;

public class EfCategoryRepository : ICategoryRepository
{
    public Task<Category> AddAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateAsync(Category category)
    {
        throw new NotImplementedException();
    }
}
