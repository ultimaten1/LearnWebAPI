using LearnWebAPI.Data;
using LearnWebAPI.Models;

namespace LearnWebAPI.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<ProductModel> GetAllProducts(string search)
        {
            var allProducts = _context.Products.Where(p => p.ProductName.Contains(search));

            var result = allProducts.Select(hh => new ProductModel
            {
                ProductId = hh.ProductId,
                ProductName = hh.ProductName,
                Price = hh.Price,
                TypeName = hh.Type.TypeName
            });

            return result.ToList();
        }
    }
}
