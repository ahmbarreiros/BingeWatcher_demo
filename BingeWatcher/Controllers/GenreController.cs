using Microsoft.AspNetCore.Mvc;
using BingeWatcher.DataAccess.Repository.IRepository;
using BingeWatcher.Models;

namespace BingeWatcher.Controllers
{
    public class GenreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenreController(IUnitOfWork unitOfWork)
        {
             _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Genre> genresList = _unitOfWork.GenreRepository.GetAll().ToList();
            return View(genresList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GenreRepository.Add(obj);
                _unitOfWork.SaveChanges();
                TempData["Success"] = "Gênero criado!";
                return RedirectToAction("Index");
            } else
            {
                TempData["Error"] = "Erro ao criar gênero.";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            } else
            {
                Genre obj = _unitOfWork.GenreRepository.GetFirstOrDefault(u => u.Id == id);
                if(obj == null)
                {
                    return NotFound();
                } else
                {
                    return View(obj);
                }
            }
        }

        [HttpPost]
        public IActionResult Edit(Genre obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GenreRepository.Update(obj);
                _unitOfWork.SaveChanges();
                TempData["Success"] = "Gênero editado!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Erro ao editar gênero.";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                Genre obj = _unitOfWork.GenreRepository.GetFirstOrDefault(u => u.Id == id);
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(obj);
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Genre? obj = _unitOfWork.GenreRepository.GetFirstOrDefault(u => u.Id == id);
            if(obj == null)
            {
                TempData["Error"] = "Erro ao remover gênero.";
                return RedirectToAction("Index");
            }
            else
            {
                _unitOfWork.GenreRepository.Delete(obj);
                _unitOfWork.SaveChanges();
                TempData["Success"] = "Gênero removido!";
                return RedirectToAction("Index");
            }
        }
    }
}
