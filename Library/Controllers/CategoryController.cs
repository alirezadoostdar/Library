
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

    public List<Category> GetAll()
    {
        return _repository.GetAll().ToList();
    }

    public Category GetInfo(int catId)
    {
       return _repository.GetById(catId);
    }

    public string Delete(int catId)
    {
        var cat = _repository.GetById(catId);
        if (cat == null)
            return "category by this Id not Found";

        if (cat.Books.Count > 0)
            return "This category has been used and cannot be deleted.";

        _repository.Delete(catId);
        return "This Category deleted successfully.";
    }

    public string Update(UpdateCategoryDto cat)
    {
        _repository.Update(new Category { Id = cat.Id, Title = cat.Title});
        return "The category updated successfully.";
    }
}
