using Library.Application.Dtos.Categories;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class CategoryServices : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryServices(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<int> AddAsync(AddCategoryDto dto)
    {
        Category category = new Category
        {
            Title = dto.Title,
        };

        await _categoryRepository.AddAsync(category);
        return category.Id;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<GetCategoryDto> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetCategoryDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateCategoryDto dto)
    {
        throw new NotImplementedException();
    }
}
