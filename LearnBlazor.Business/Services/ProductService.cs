using LearnBlazor.Business.Repositories;
using LearnBlazor.Model.Entities;

namespace LearnBlazor.Business.Services
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProducts();

        Task<ProductModel> CreateProduct(ProductModel model);

        Task<ProductModel> GetProduct(int id);

        Task<bool> ProductModelExists(int id);

        Task UpdateProduct(ProductModel model);

        Task DeleteProduct(int id);
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

        public Task<ProductModel> GetProduct(int id)
        {
            return productRepository.GetProduct(id);
        }

        public Task<bool> ProductModelExists(int id)
        {
            return productRepository.ProductModelExists(id);
        }

        public Task UpdateProduct(ProductModel model)
        {
            return productRepository.UpdateProduct(model);
        }

        public Task DeleteProduct(int id)
        {
            return productRepository.DeleteProduct(id);
        }
    }
}