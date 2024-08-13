using LearnWebAPI.Models;

namespace LearnWebAPI.Services
{
    public interface IProductRepository
    {
        List<ProductModel> GetAllProducts(string search);
    }
}
