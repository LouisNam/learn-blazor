using LearnBlazor.Database.Data;
using LearnBlazor.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnBlazor.Business.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetProducts();

        Task<ProductModel> CreateProduct(ProductModel model);
    }

    public class ProductRepository(AppDbContext dbContext) : IProductRepository
    {
        public Task<List<ProductModel>> GetProducts()
        {
            return dbContext.Products.ToListAsync();
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            dbContext.Add(model);
            await dbContext.SaveChangesAsync();
            return model;
        }
    }
}