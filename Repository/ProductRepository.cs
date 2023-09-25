using LayeredApp.Infrastructure;
using LayeredApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace LayeredApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext db;

        public ProductRepository(DataContext db)
        {
            this.db = db;
        }

        void IProductRepository.AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        void IProductRepository.DeleteProduct(int id)
        {
            var p = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            db.Products.Remove(p);
            db.SaveChanges();
        }

        Product IProductRepository.GetProduct(int id)
        {
            return db.Products.Where(x => x.ProductId == id).FirstOrDefault();    
        }

        List<Product> IProductRepository.GetProducts()
        {
            return db.Products.ToList();
        }
    }
}
