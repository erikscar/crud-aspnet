using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class ProvidersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
