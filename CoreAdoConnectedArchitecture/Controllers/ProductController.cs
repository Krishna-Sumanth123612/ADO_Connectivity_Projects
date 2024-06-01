using CoreAdoConnectedArchitecture.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Data.SqlClient;

namespace CoreAdoConnectedArchitecture.Controllers
{
    public class ProductController : Controller
    {
        public IConfiguration Configuration { get; }
        public ProductController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            List<Product> ProductList = new List<Product>();
            //string connectionString = "Data Source=LAPTOP-K1ET6H70;Initial Catalog=SampleDb;Integrated Security=true;";
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select * from Product", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                    product.ProductName = reader["ProductName"].ToString();
                    product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"].ToString());
                    product.ProductQuantity = Convert.ToInt32(reader["ProductQuantity"].ToString());

                    ProductList.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return View(ProductList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            //string connectionString = "Data Source=LAPTOP-K1ET6H70;Initial Catalog=SampleDb;Integrated Security=true;";
            string connectionString = "Data Source=LAPTOP-K1ET6H70;Initial Catalog=SampleDb;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "INSERT INTO Product VALUES (@name, @price, @quantity)";
                SqlCommand command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@name", model.ProductName);
                command.Parameters.AddWithValue("@price", model.ProductPrice);
                command.Parameters.AddWithValue("@quantity", model.ProductQuantity);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                   return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Product product = new Product();
            //string connectionString = "Data Source=LAPTOP-K1ET6H70;Initial Catalog=SampleDb;Integrated Security=true;";
            string connectionString = "Data Source=LAPTOP-K1ET6H70;Initial Catalog=SampleDb;Integrated Security=true;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "Select * from Product Where ProductId=@id";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                            product.ProductName = reader["ProductName"].ToString();
                            product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"].ToString());
                            product.ProductQuantity = Convert.ToInt32(reader["ProductQuantity"].ToString());
                        }
                    }
                }
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product model, int id)
        {
            if (ModelState.IsValid)
            {
                string connectionString = "Data Source=LAPTOP-K1ET6H70;Initial Catalog=SampleDb;Integrated Security=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "Update Product Set Productname=@name,ProductPrice=@price," +
                        " ProductQuantity = @quantity Where ProductId = " + id;
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@name", model.ProductName);
                            command.Parameters.AddWithValue("@price", model.ProductPrice);
                            command.Parameters.AddWithValue("@quantity", model.ProductQuantity);
                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                return RedirectToAction("Index");
                            }
                        }
                        catch (Exception ex)
                        {
                            ViewBag.ErrorMessage = ex.Message;
                        }
                    }
                }
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            Product product = new Product();
            //string connectionString = "Data Source=LAPTOP-K1ET6H70;Initial Catalog=SampleDb;Integrated Security=true;";
            string connectionString = "Data Source=LAPTOP-K1ET6H70;Initial Catalog=SampleDb;Integrated Security=true;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "Select * from Product Where ProductId=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                            product.ProductName = reader["ProductName"].ToString();
                            product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"].ToString());
                            product.ProductQuantity = Convert.ToInt32(reader["ProductQuantity"].ToString());
                        }
                    }
                }
            }

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            Product product = new Product();
            //string connectionString = "Data Source=LAPTOP-K1ET6H70;Initial Catalog=SampleDb;Integrated Security=true;";
            string connectionString = "Data Source=LAPTOP-K1ET6H70;Initial Catalog=SampleDb;Integrated Security=true;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "Select * from Product Where ProductId=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                            product.ProductName = reader["ProductName"].ToString();
                            product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"].ToString());
                            product.ProductQuantity = Convert.ToInt32(reader["ProductQuantity"].ToString());
                        }
                    }
                }
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product model, int id)
        {
            //string connectionString = "Data Source=LAPTOP-K1ET6H70;Initial Catalog=SampleDb;Integrated Security=true;";
            string connectionString = "Data Source=LAPTOP-K1ET6H70;Initial Catalog=SampleDb;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "Delete from Product Where ProductId = " + id;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = ex.Message;
                    }
                }
            }
            return View();
                
        }

    }
}
