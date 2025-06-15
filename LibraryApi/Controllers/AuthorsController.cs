using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("")]
public class AuthorsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
