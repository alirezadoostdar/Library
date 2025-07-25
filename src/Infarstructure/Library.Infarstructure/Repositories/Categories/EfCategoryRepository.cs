﻿using Library.Domain.Entities;
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

    public async Task<Category> AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task DeleteAsync(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public bool IsExistTitle(string title, int id = 0) 
    {
        var result = _context.Categories.Any(c => c.Title == title && c.Id != id);
        return result;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(category.Id);
    }
}
