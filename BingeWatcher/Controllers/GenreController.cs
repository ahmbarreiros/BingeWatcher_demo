using Microsoft.AspNetCore.Mvc;

namespace BingeWatcher.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
