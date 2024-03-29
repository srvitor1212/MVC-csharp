﻿using Cerveja.Models.ViewModels;
using Cerveja.Models;
using Cerveja.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cerveja.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            this._vendedorService = vendedorService;
            this._departamentoService = departamentoService;
        }

        //Method GET
        public IActionResult Index()
        {
            var list = _vendedorService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var deps = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = deps };
            return View(viewModel);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _vendedorService.FindById(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _vendedorService.FindById(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }
        public IActionResult Edit(int id)
        {
            if (id == null)
                return NotFound();

            var vendedor = _vendedorService.FindById(id);
            if (vendedor == null)
                return NotFound();

            var deps = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = deps };

            return View(viewModel);
        }

        //Method POST
        [HttpPost] [ValidateAntiForgeryToken]
        public IActionResult Edit(Vendedor vendedor)
        {
            _vendedorService.Update(vendedor);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost] [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedorService.Remove(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost] [ValidateAntiForgeryToken] //Isso é uma Notation
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
