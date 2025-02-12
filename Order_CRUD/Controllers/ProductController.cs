using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_CRUD.DTOs.RequstDTOs;
using Order_CRUD.Entities;
using Order_CRUD.IServices;
using Order_CRUD.Services;

namespace Order_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductRequestDTO productRequest)
        {
            try
            {
                var data = await _productService.AddProduct(productRequest);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var data = await _productService.GetProduct(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var data = await _productService.GetAllProducts();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            try
            {
                var data = await _productService.UpdateProduct(id, product);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var data = await _productService.DeleteProduct(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
