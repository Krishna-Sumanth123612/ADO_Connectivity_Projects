using CoreAdoConnectedArchitecture.DAL;
using CoreAdoConnectedArchitecture.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Data.SqlClient;

namespace CoreAdoConnectedArchitecture.Controllers
{
    public class ProductController : Controller
    {
        public ProductDataAccessLayer productDAL;
        public ProductController(IConfiguration configuration)
        {
            productDAL = new ProductDataAccessLayer(configuration);
        }
        public IActionResult Index()
        {
            return View(productDAL.GetProducts());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            productDAL.AddProduct(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(productDAL.GetProduct(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Product model)
        {
            productDAL.EditProduct(id, model);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(productDAL.GetProduct(id));
        }

        public IActionResult Delete(int id)
        {
            return View(productDAL.GetProduct(id));
        }

        [HttpPost]
        public IActionResult Delete(Product model, int id)
        {
            productDAL.DeleteProduct(id);
            return RedirectToAction("Index");
                
        }

    }
}
