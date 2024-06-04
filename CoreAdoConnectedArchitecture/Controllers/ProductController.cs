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
            try
            {
                productDAL.AddProduct(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            Product product = productDAL.GetProduct(id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Edit(int id, Product model)
        {
            try
            {
                productDAL.EditProduct(id, model);
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            Product product = productDAL.GetProduct(id);
            if (product != null)
            {
                return View(product);
            }
            else {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id)
        {
            Product product = productDAL.GetProduct(id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Delete(Product model, int id)
        {
            try
            {
                productDAL.DeleteProduct(id);
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                return View();
            }
                
        }

    }
}
