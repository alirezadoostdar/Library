using Library.Application.Dtos.Categories;

namespace Library.Application.Interfaces;

public interface ICategoryService
{
    Task<GetCategoryDto> GetByIdAsync(int id);
    Task<int> AddAsync(AddCategoryDto dto);
    Task UpdateAsync(UpdateCategoryDto dto);
    Task DeleteAsync(int id);
    Task<GetCategoryDto> GetAllAsync();
    
}


