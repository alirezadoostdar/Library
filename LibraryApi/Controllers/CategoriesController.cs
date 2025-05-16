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

        [HttpGet("{id:int}")]
        public GetCategoryDto GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            GetCategoryDto getCategoryDto = new();
            if (category != null)
            {
                getCategoryDto.Title = category.Title;
                getCategoryDto.Id = category.Id;
            }

            return getCategoryDto;
        }

        [HttpPut("{id:int}")]
        public void Update(int id, UpdateCategoryDto dto)
        {
            var category = _categoryRepository.GetById(id);
            if(category is  not null)
            {
                category.Title = dto.Title;
                _categoryRepository.Update(category);
            }
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
            if(category is not null)
            {
                _categoryRepository.Remove(category);
            }
        }
    }
}
