using Microsoft.EntityFrameworkCore;
using Order_CRUD.Database;
using Order_CRUD.Entities;
using Order_CRUD.IRepositories;


namespace Order_CRUD.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBcontext _dbcontext;
        public ProductRepository(AppDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var addedProduct = await _dbcontext.Products.AddAsync(product);
            await _dbcontext.SaveChangesAsync();
            return addedProduct.Entity;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbcontext.Products.ToListAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _dbcontext.Products.SingleOrDefaultAsync(product => product.Id == id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var updatedProduct = _dbcontext.Products.Update(product);
            await _dbcontext.SaveChangesAsync();
            return updatedProduct.Entity;
        }

        public async Task<string> DeleteProduct(Product product)
        {
            var deleteProduct = _dbcontext.Products.Remove(product);
            await _dbcontext.SaveChangesAsync();
            return "Successfully deleted";
        }
    }
}
