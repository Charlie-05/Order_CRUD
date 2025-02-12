using Order_CRUD.Entities;

namespace Order_CRUD.IRepositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<Order> GetOrderById(int id);
        Task<List<Order>> GetAllOrders();
        Task<string> DeleteOrder(Order order);
    }
}
