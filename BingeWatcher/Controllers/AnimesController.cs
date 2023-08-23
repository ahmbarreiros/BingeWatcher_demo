using Microsoft.AspNetCore.Mvc;

namespace BingeWatcher.Controllers
{
    public class AnimesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
