using Order_CRUD.DTOs.RequstDTOs;
using Order_CRUD.Entities;

namespace Order_CRUD.IServices
{
    public interface IProductService
    {
        Task<Product> AddProduct(ProductRequestDTO product);
        Task<Product> GetProduct(int id);
        Task<List<Product>> GetAllProducts();
        Task<string> DeleteProduct(int id);
        Task<Product> UpdateProduct(int id, Product product);
    }
}
