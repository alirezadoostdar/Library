using Library.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : Controller
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _categoryRepository.GetByIdAsync(id);
        return Ok(result);
    }
}
