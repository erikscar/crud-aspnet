using CRUD.Models;
using CRUD.Models.ViewModels;
using CRUD.Services;
using CRUD.Services.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            //Verificação Server-Side se os campos foram preenchidos corretamente
            if (ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new ProviderFormViewModel { Departments = departments, Provider = provider };
                return View(viewModel);
            }
            //Método Criado na Aba Services para Inserir um novo Provider
            _providerService.Insert(provider);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "ID Not Provided"});
            }

            //Tem que se utilizar o VAlue porque é um Nulable
            var obj = _providerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not Found" });
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
                return RedirectToAction(nameof(Error), new { message = "ID Not Provided" });
            }

            //Tem que se utilizar o VAlue porque é um Nulable
            var obj = _providerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not Found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not Provided" });
            }

            var obj = _providerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not Found" });
            }

            List<Department> departments = _departmentService.FindAll();
            ProviderFormViewModel viewModel = new ProviderFormViewModel { Provider = obj, Departments = departments };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Provider provider)
        {
            //Verificação Server-Side se os campos foram preenchidos corretamente
            if (ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new ProviderFormViewModel { Departments = departments, Provider = provider };
                return View(viewModel);
            }
            if (id != provider.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Missmatch" });
            }

            try
            {
                _providerService.Update(provider);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
