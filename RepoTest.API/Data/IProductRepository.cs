using System.Threading.Tasks;
using AutoMapper;
using RepoTest.API.Dtos;
using RepoTest.API.Models;

namespace RepoTest.API.Data
{
    public interface IProductRepository
    {
        public Task Add(Product product);

        public Task Remove(Product product);

        public Task<ProductDtos> GetById(int id);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper mapper;
        public ProductRepository(DataContext _context, IMapper mapper)
        {
            this.mapper = mapper;
            this._context = _context;
        }

        public ProductRepository() {}
        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task Remove(Product product)
        {
            _context.Products.Remove(product);
        }
        public async Task<ProductDtos> GetById(int id) { return mapper.Map<ProductDtos>(await _context.Products.FindAsync(id));}
    }
}