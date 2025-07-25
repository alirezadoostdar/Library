﻿using Library.Application.Dtos.Categories;

namespace Library.Application.Interfaces;

public interface ICategoryService
{
    Task<GetCategoryDto> GetByIdAsync(int id);
    Task<int> AddAsync(AddCategoryDto dto);
    Task UpdateAsync(int id, UpdateCategoryDto dto);
    Task DeleteAsync(int id);
    Task<List<GetCategoryDto>> GetAllAsync();   
}


