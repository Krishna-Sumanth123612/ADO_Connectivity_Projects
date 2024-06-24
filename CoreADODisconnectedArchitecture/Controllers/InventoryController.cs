using Microsoft.AspNetCore.Mvc;

namespace CoreADODisconnectedArchitecture.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
