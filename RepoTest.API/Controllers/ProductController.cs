using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepoTest.API.Data;
using RepoTest.API.Models;

namespace RepoTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repo;
        public ProductController(IProductRepository repo) { 
            this.repo = repo;
        }

        [HttpGet("{id}", Name ="GetProduct")]
        public async Task<ActionResult<Product>> getProduct(int id) { 
            var product =  await repo.GetById(id);
            if (product == null){
                return NotFound();
            }
            return Ok(product);
        }
    }
}