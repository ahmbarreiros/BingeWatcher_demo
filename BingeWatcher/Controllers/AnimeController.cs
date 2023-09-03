using BingeWatcher.Data;
using Microsoft.AspNetCore.Mvc;


namespace BingeWatcher.Controllers
{
    public class AnimeController : Controller
    {
        public readonly AppDbContext _db;
        public AnimeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
