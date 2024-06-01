using CoreAdoConnectedArchitecture.Models;

namespace CoreAdoConnectedArchitecture.DAL
{
    public interface IProductDataAccessLayer
    {
        public IEnumerable<Product> GetProducts();
        public void AddProduct(Product model);
        public void EditProduct(int id, Product model);
        public Product GetProduct(int id);
        public void DeleteProduct(int id);
    }
}
