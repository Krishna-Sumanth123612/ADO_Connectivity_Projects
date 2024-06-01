using CoreAdoConnectedArchitecture.Models;
using System.Data.SqlClient;
using System.Reflection;

namespace CoreAdoConnectedArchitecture.DAL
{
    public class ProductDataAccessLayer : IProductDataAccessLayer
    {
        public IConfiguration Configuration { get; }
        public ProductDataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void AddProduct(Product model)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "INSERT INTO Product VALUES (@name, @price, @quantity)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", model.ProductName);
                command.Parameters.AddWithValue("@price", model.ProductPrice);
                command.Parameters.AddWithValue("@quantity", model.ProductQuantity);
                int result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteProduct(int id)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "Delete from Product Where ProductId = " + id;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        int result = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        public void EditProduct(int id, Product model)
        {
            if (model != null)
            {
                string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "Update Product Set Productname=@name,ProductPrice=@price," +
                        " ProductQuantity = @quantity Where ProductId = " + id;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@name", model.ProductName);
                            command.Parameters.AddWithValue("@price", model.ProductPrice);
                            command.Parameters.AddWithValue("@quantity", model.ProductQuantity);
                            int result = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
        }

        public Product GetProduct(int id)
        {
            Product product = new Product();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
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
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            List<Product> ProductList = new List<Product>();
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
            return ProductList;
        }
    }
}
