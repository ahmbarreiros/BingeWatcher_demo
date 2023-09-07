using BingeWatcher.Data;
using BingeWatcher.DataAccess.Repository.IRepository;
using BingeWatcher.Models;
using BingeWatcher.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BingeWatcher.Areas.Admin.Controllers
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

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> GenreList = _unitOfWork.GenreRepository.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            AnimeVM animeVM = new()
            {
                GenreList = GenreList,
                Anime = new Anime()
            };

            if (id == null || id == 0)
            {
                return View(animeVM);
            }
            else
            {
                animeVM.Anime = _unitOfWork.AnimeRepository.GetFirstOrDefault(u => u.Id == id);
                return View(animeVM);
            }

        }

        [HttpPost]
        public IActionResult Upsert(AnimeVM animeVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string animePath = Path.Combine(wwwRootPath, @"images\anime\");

                    if (!string.IsNullOrEmpty(animeVM.Anime.Main_Picture))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, animeVM.Anime.Main_Picture.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(animePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    animeVM.Anime.Main_Picture = @"\images\anime\" + fileName;
                }

                if (animeVM.Anime.Id == 0)
                {
                    _unitOfWork.AnimeRepository.Add(animeVM.Anime);
                    TempData["success"] = "Anime criado com sucesso!";
                }
                else
                {
                    _unitOfWork.AnimeRepository.Update(animeVM.Anime);
                    TempData["success"] = "Anime atualizado com sucesso!";
                }

                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                animeVM.GenreList = _unitOfWork.GenreRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                TempData["error"] = "erro ao criar/atualizar produto.";
                return RedirectToAction("Index");
            }
        }
    }
}
