using LibraryApi.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public void Add(AddCategoryDto dto)
        {
            var category = new Category { Title = dto.Title };
            _categoryRepository.Add(category);
        }

        [HttpGet]
        public List<GetCategoryDto> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        [HttpPut]
        public UpdateCategoryDto Update(UpdateCategoryDto dto)
        {
            var category = _categoryRepository.GetById(dto.Id);
            if(category is  not null)
            {
                category.Title = dto.Title;
                _categoryRepository.Update(category);
                return dto;
            }
            return null;
        }
    }
}
