using LearnBlazor.Database.Data;
using LearnBlazor.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnBlazor.Business.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetProducts();

        Task<ProductModel> CreateProduct(ProductModel model);

        Task<ProductModel> GetProduct(int id);

        Task<bool> ProductModelExists(int id);

        Task UpdateProduct(ProductModel model);

        Task DeleteProduct(int id);
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

        public Task<ProductModel> GetProduct(int id)
        {
            return dbContext.Products.FirstOrDefaultAsync(x => x.ID == id);
        }

        public Task<bool> ProductModelExists(int id)
        {
            return dbContext.Products.AnyAsync(x => x.ID == id);
        }

        public async Task UpdateProduct(ProductModel model)
        {
            dbContext.Entry(model).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.ID == id);
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }
    }
}