using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class ProvidersRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SimpleSearch()
        {
            return View();
        }
        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
