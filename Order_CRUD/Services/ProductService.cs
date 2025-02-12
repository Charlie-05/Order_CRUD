using Order_CRUD.DTOs.RequstDTOs;
using Order_CRUD.DTOs.ResponseDTOs;
using Order_CRUD.Entities;
using Order_CRUD.IRepositories;
using Order_CRUD.IServices;

namespace Order_CRUD.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> AddProduct(ProductRequestDTO productRequest)
        {
            var product = new Product();
            product.Price = productRequest.Price;
            product.Name = productRequest.Name;
            product.Description = productRequest.Description;
            product.Category = productRequest.Category;
            product.Stock = productRequest.Stock;
            var addProduct = await _productRepository.AddProduct(product);
            return addProduct;
        }

        public async Task<Product> GetProduct(int id)
        {
            var getProduct = await _productRepository.GetProductById(id) ?? throw new Exception("Product Not found");
            return getProduct;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return products;
        }

        public async Task<string> DeleteProduct(int id)
        {
            var getProduct = await _productRepository.GetProductById(id) ?? throw new Exception("Product Not found");
            return await _productRepository.DeleteProduct(getProduct);
        }

        public async Task<Product> UpdateProduct(int id, ProductRequestDTO productRequest)
        {
            var getProduct = await _productRepository.GetProductById(id) ?? throw new Exception("Product Not found");
            getProduct.Name = productRequest.Name;
            getProduct.Description = productRequest.Description;
            getProduct.Price = productRequest.Price;
            getProduct.Stock = productRequest.Stock;
            getProduct.Category = productRequest.Category;
            var updateProduct = await _productRepository.UpdateProduct(getProduct);
            return updateProduct;
        }
    }
}
