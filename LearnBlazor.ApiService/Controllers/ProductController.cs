using LearnBlazor.Business.Services;
using LearnBlazor.Model.Entities;
using LearnBlazor.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnBlazor.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetProducts()
        {
            var products = await productService.GetProducts();
            return Ok(new BaseResponseModel { Success = true, Data = products });
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> CreateProduct(ProductModel productModel)
        {
            await productService.CreateProduct(productModel);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetProduct(int id)
        {
            var product = await productService.GetProduct(id);
            if (product == null)
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Not found" });
            }
            return Ok(new BaseResponseModel { Success = true, Data = product });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponseModel>> UpdateProduct(int id, ProductModel model)
        {
            if (id != model.ID || !await productService.ProductModelExists(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Not found" });
            }

            await productService.UpdateProduct(model);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponseModel>> DeleteProduct(int id)
        {
            if (!await productService.ProductModelExists(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Not found" });
            }

            await productService.DeleteProduct(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}