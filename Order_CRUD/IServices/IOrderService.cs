using Order_CRUD.DTOs.RequstDTOs;
using Order_CRUD.DTOs.ResponseDTOs;

namespace Order_CRUD.IServices
{
    public interface IOrderService
    {
        Task<OrderResponseDTO> AddOrder(OrderRequestDTO orderRequestDTO);
        Task<OrderResponseDTO> GetOrderById(int id);
        Task<List<OrderResponseDTO>> GetAllOrders();
        Task<string> DeleteOrder(int id);
        Task<OrderResponseDTO> UpdateOrder(int id, OrderRequestDTO orderRequestDTO);
    }
}
