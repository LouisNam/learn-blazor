using LearnBlazor.Business.Repositories;
using LearnBlazor.Model.Entities;

namespace LearnBlazor.Business.Services
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProducts();

        Task<ProductModel> CreateProduct(ProductModel model);
    }

    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public Task<List<ProductModel>> GetProducts()
        {
            return productRepository.GetProducts();
        }

        public Task<ProductModel> CreateProduct(ProductModel model)
        {
            return productRepository.CreateProduct(model);
        }
    }
}