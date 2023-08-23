using Microsoft.AspNetCore.Mvc;


namespace BingeWatcher.Controllers
{
    public class AnimeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
