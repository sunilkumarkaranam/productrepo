using LayeredApp.Models;

namespace LayeredApp.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);   
        void DeleteProduct(int id);
    }
}
