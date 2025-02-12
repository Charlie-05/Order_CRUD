

using Order_CRUD.Entities;

namespace Order_CRUD.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product order);
        Task<Product> UpdateProduct(Product order);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
        Task<string> DeleteProduct(Product order);
    }
}
