using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class ProvidersController : Controller
    {
        private readonly ProviderService _providerService;

        public ProvidersController(ProviderService providerService)
        {
            //Injeçao de Dependência
            _providerService = providerService;
        }
        public IActionResult Index()
        {
            var list = _providerService.FindAll();
            //Passando todos os Providers para a View
            return View(list);
        }

        public IActionResult Create()
        {
            //Retornando apenas a View Create
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Provider provider)
        {
            //Método Criado na Aba Services
            _providerService.Insert(provider);
            return RedirectToAction(nameof(Index));
        }
    }
}
