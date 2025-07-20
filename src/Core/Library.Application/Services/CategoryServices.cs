using Library.Application.Categories.Contracts.Exceptions;
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
        var isExistsTitle = _categoryRepository.IsExistTitle(dto.Title);
        if (isExistsTitle)
            throw new CategoryTitleIsDuplicateExcptions();

        Category category = new Category
        {
            Title = dto.Title,
        };

        await _categoryRepository.AddAsync(category);
        return category.Id;
    }

    public async Task DeleteAsync(int id)
    {
        await _categoryRepository.DeleteAsync(id);
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

    public async Task<GetCategoryDto> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null)
            throw new FileNotFoundException();

        var dto = new GetCategoryDto
            (
            category.Id,
            category.Title
            );

        return dto;
    }

    public async Task UpdateAsync(int id, UpdateCategoryDto dto)
    {
        var Category = await _categoryRepository.GetByIdAsync(dto.Id);
        Category.Title = dto.Title;

        await _categoryRepository.UpdateAsync(Category);
    }
}
