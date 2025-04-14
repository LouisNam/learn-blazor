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
    }
}