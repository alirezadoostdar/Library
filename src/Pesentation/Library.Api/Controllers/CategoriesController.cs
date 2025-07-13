using Library.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

using Library.Application.Interfaces;
using Library.Application.Dtos.Categories;

namespace Library.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _categoryService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllAsync()
    {
        return Ok(await _categoryService.GetAllAsync());
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync(AddCategoryDto dto)
    {
        var result = await _categoryService.AddAsync(dto);
        return Ok(result);
    }
}
