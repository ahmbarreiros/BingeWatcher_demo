using BingeWatcher.DataAccess.Repository.IRepository;
using BingeWatcher.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BingeWatcher.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Anime> animes = _unitOfWork.AnimeRepository.GetAll(includeProperties: "Genre");
            if(animes != null)
            {
                return View(animes);
            } else
            {
                return NotFound();
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Details(int? id)
        {
            Anime anime = _unitOfWork.AnimeRepository.GetFirstOrDefault(u => u.Id == id, includeProperties: "Genre");
            if (anime == null)
            {
                return NotFound();

            }
            else
            {
                return View(anime);
            }
        }
    }
}
