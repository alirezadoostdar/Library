using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;


[ApiController]
[Route("api/books")]
public class BooksController : Controller
{
    private readonly 
    public IActionResult Index()
    {
        return View();
    }
}
