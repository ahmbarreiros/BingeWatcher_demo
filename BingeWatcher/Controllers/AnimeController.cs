using BingeWatcher.Data;
using BingeWatcher.DataAccess.Repository.IRepository;
using BingeWatcher.Models;
using Microsoft.AspNetCore.Mvc;


namespace BingeWatcher.Controllers
{
    public class AnimeController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AnimeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Anime> animeList = _unitOfWork.AnimeRepository.GetAll().ToList();
            return View(animeList);
        }
    }
}
