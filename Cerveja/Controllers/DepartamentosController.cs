using System.Diagnostics;
using Cerveja.Models.ViewModels;
using Cerveja.Services;
using Microsoft.AspNetCore.Mvc;
using Cerveja.Models;
using Cerveja.Services.Exceptions;

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
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dep = _departamentoService.FindById(id.Value);
            if (dep == null)
                return NotFound();

            return View(dep);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento dep)
        {
            try
            {
                _departamentoService.Update(dep);
                return RedirectToAction(nameof(Index));
            } 
            catch (ServiceNotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { msg = e.Message });
            }
            catch (ServiceConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { msg = e.Message });
            }
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

        //-----------------------------------------------------------------------------------------------------
        public IActionResult Error(string msg)
        {
            var viewModel = new ErrorViewModel {
                Message = msg,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
