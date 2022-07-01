using Cerveja.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cerveja.Data;
using Cerveja.Models;

namespace Cerveja.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly DepartamentoService _departamentoService;

        public DepartamentosController(DepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        //-----------------------------------------------------------------------------------------------------
        public IActionResult Index()
        {
            var list = _departamentoService.FindAll();
            return View(list);
        }

        //-----------------------------------------------------------------------------------------------------
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento dep)
        {
            _departamentoService.Insert(dep);
            return RedirectToAction(nameof(Index));
        }

        //-----------------------------------------------------------------------------------------------------
        public IActionResult Edit(int id)
        {
            if (id == null)
                return NotFound();

            var dep = _departamentoService.FindById(id);
            if (dep == null)
                return NotFound();

            return View(dep);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento dep)
        {
            _departamentoService.Update(dep);
            return RedirectToAction(nameof(Index));
        }

        //-----------------------------------------------------------------------------------------------------
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _departamentoService.FindById(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //-----------------------------------------------------------------------------------------------------
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _departamentoService.FindById(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _departamentoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
