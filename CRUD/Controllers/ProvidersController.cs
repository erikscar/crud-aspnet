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
        public async Task<IActionResult> Index()
        {
            var list = await _providerService.FindAllAsync();
            //Passando todos os Providers para a View
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new ProviderFormViewModel { Departments = departments };
            //Retornando apenas a View Create
            //Agora a view vai receber os departamentos buscados 
            return View(viewModel);
        }
        //Annotation para Definir que é um método Post
        [HttpPost]
        //Maior Segurança
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Provider provider)
        {
            //Verificação Server-Side se os campos foram preenchidos corretamente
            if (ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new ProviderFormViewModel { Departments = departments, Provider = provider };
                return View(viewModel);
            }
            //Método Criado na Aba Services para Inserir um novo Provider
            await _providerService.InsertAsync(provider);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "ID Not Provided"});
            }

            //Tem que se utilizar o VAlue porque é um Nulable
            var obj = await _providerService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not Found" });
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _providerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            //Caso ocorra essa exceção redirecionar para a página
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not Provided" });
            }

            //Tem que se utilizar o VAlue porque é um Nulable
            var obj = await _providerService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not Found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not Provided" });
            }

            var obj = await _providerService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not Found" });
            }

            List<Department> departments = await _departmentService.FindAllAsync();
            ProviderFormViewModel viewModel = new ProviderFormViewModel { Provider = obj, Departments = departments };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Provider provider)
        {
            //Verificação Server-Side se os campos foram preenchidos corretamente
            if (ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new ProviderFormViewModel { Departments = departments, Provider = provider };
                return View(viewModel);
            }
            if (id != provider.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Missmatch" });
            }

            try
            {
                await _providerService.UpdateAsync(provider);
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
