using Microsoft.EntityFrameworkCore;
using Order_CRUD.Database;
using Order_CRUD.Entities;
using Order_CRUD.IRepositories;

namespace Order_CRUD.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBcontext _dbcontext;

        public OrderRepository(AppDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
 
        public async Task<Order> AddOrder(Order order)
        {
            var addedOrder = await _dbcontext.Orders.AddAsync(order);
            await _dbcontext.SaveChangesAsync();
            return addedOrder.Entity;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _dbcontext.Orders.ToListAsync();
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _dbcontext.Orders.SingleOrDefaultAsync(order => order.Id == id);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var updatedOrder = _dbcontext.Orders.Update(order);
            await _dbcontext.SaveChangesAsync();
            return updatedOrder.Entity;
        }

        public async Task<string> DeleteOrder(Order order)
        {
            var deleteOrder = _dbcontext.Orders.Remove(order);
            await _dbcontext.SaveChangesAsync();
            return "Successfully deleted";
        }
    }
}
