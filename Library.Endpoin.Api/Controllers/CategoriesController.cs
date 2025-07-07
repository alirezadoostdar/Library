using Microsoft.AspNetCore.Mvc;

namespace Library.Endpoin.Api.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : Controller
{

    [HttpGet]
    public List<GetCategoryDto> GetAll()
    {
        return new List<GetCategoryDto>()
        {
            new GetCategoryDto
            {
                Title = "Math"
            },
            new GetCategoryDto
            {
                Title = "History"
            }
        };
    }
    
}


public class GetCategoryDto
{
    public string Title { get; set; }

}