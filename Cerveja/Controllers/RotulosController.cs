using Cerveja.Services;
using Microsoft.AspNetCore.Mvc;
using Cerveja.Models;

namespace Cerveja.Controllers
{
    public class RotulosController : Controller
    {
        private readonly RotuloService _rotuloService;

        public RotulosController(RotuloService rotuloService)
        {
            _rotuloService = rotuloService;
        }

        //Method GET
        public IActionResult Index()
        {
            var list = _rotuloService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            if (id == null)
                return NotFound();

            var obj = _rotuloService.FindById(id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _rotuloService.FindById(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _rotuloService.FindById(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //Method POST
        [HttpPost] [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _rotuloService.Remove(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost] [ValidateAntiForgeryToken]
        public IActionResult Edit(Rotulo obj)
        {
            _rotuloService.Update(obj);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost] [ValidateAntiForgeryToken]
        public IActionResult Create(Rotulo obj)
        {
            _rotuloService.Insert(obj);
            return RedirectToAction(nameof(Index));
        }
    }
}
