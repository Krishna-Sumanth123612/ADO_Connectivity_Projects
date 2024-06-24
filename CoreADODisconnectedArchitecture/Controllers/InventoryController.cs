using CoreADODisconnectedArchitecture.DAL;
using CoreADODisconnectedArchitecture.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreADODisconnectedArchitecture.Controllers
{
    public class InventoryController : Controller
    {
        public InventoryAccessLayer inventoryDAL;
        public InventoryController(IConfiguration configuration)
        {
            inventoryDAL = new InventoryAccessLayer(configuration);
        }
        public IActionResult Index()
        {
            return View(inventoryDAL.GetInventories());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Inventory inventory)
        {
            try
            {
                inventoryDAL.AddInventory(inventory);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult Details(int id)
        {
            return View(inventoryDAL.GetInventory(id));
        }

        public IActionResult Edit(int id)
        {
            return View(inventoryDAL.GetInventory(id));
        }
        [HttpPost]
        public IActionResult Edit(int id, Inventory inventory)
        {
            try
            {
                inventoryDAL.EditInventory(id, inventory);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            return View(inventoryDAL.GetInventory(id));
        }

        [HttpPost]
        public IActionResult Delete(int id,Inventory inventory)
        {
            try
            {
                inventoryDAL.DeleteInventory(id, inventory);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
