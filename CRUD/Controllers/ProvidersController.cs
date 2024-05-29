﻿using CRUD.Models;
using CRUD.Models.ViewModels;
using CRUD.Services;
using CRUD.Services.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class ProvidersController : Controller
    {
        private readonly ProviderService _providerService;
        private readonly DepartmentsService _departmentService;

        public ProvidersController(ProviderService providerService, DepartmentsService departmentService)
        {
            //Injeçao de Dependência
            _providerService = providerService;
            _departmentService = departmentService; 
        }
        public IActionResult Index()
        {
            var list = _providerService.FindAll();
            //Passando todos os Providers para a View
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new ProviderFormViewModel { Departments = departments };
            //Retornando apenas a View Create
            //Agora a view vai receber os departamentos buscados 
            return View(viewModel);
        }
        //Annotation para Definir que é um método Post
        [HttpPost]
        //Maior Segurança
        [ValidateAntiForgeryToken]
        public IActionResult Create(Provider provider)
        {
            //Método Criado na Aba Services para Inserir um novo Provider
            _providerService.Insert(provider);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Tem que se utilizar o VAlue porque é um Nulable
            var obj = _providerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _providerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            //Tem que se utilizar o VAlue porque é um Nulable
            var obj = _providerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _providerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            List<Department> departments = _departmentService.FindAll();
            ProviderFormViewModel viewModel = new ProviderFormViewModel { Provider = obj, Departments = departments };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Provider provider)
        {
            if (id != provider.Id)
            {
                return BadRequest();
            }

            try
            {
                _providerService.Update(provider);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch(DbConcurrencyException)
            {
                return BadRequest();
            }

        }
    }
}
