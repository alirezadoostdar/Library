
using Library.Interfaces;
using Library.Models.Categories;

namespace Library.Controllers;

public class CategoryController
{
    private readonly ICategoryRepository _repository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _repository = categoryRepository;
    }

    public void Create(CreateCategoryDto category)
    {
        if (! _repository.IsDupplicat(category.Title))
        {
            var cat = new Category()
            {
                Id = 0,
                Title = category.Title,
            };
            _repository.Add(cat);
        }

    }
}
