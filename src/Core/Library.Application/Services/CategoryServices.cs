using Library.Application.Dtos.Categories;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
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

    public async Task<List<GetCategoryDto>> GetAllAsync()
    {
        var catgoeries = await _categoryRepository.GetAllAsync();
        var CategoryList = catgoeries.Select(x => new GetCategoryDto
        (
            x.Id,
            x.Title
        )).ToList();

        return CategoryList;
    }

    public Task<GetCategoryDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(UpdateCategoryDto dto)
    {
        var Category = await _categoryRepository.GetByIdAsync(dto.Id);
        Category.Title = dto.Title;

        await _categoryRepository.UpdateAsync(Category);
    }
}
