using LayeredApp.Models;
using LayeredApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LayeredApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(repo.GetProducts());
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            repo.AddProduct(product);
            return Ok("Product Addedd");
        }
    }
}
