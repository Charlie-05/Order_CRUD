using Order_CRUD.DTOs.RequstDTOs;
using Order_CRUD.DTOs.ResponseDTOs;
using Order_CRUD.Entities;
using Order_CRUD.IRepositories;
using Order_CRUD.IServices;
using Order_CRUD.Repositories;

namespace Order_CRUD.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository) {
            _orderRepository = orderRepository;
        }
        public async Task<OrderResponseDTO> AddOrder(OrderRequestDTO orderRequestDTO)
        {
            var order = this.OrderRequestToOrder(orderRequestDTO);
            var newOrder = await _orderRepository.AddOrder(order);
            return this.OrderToOrderResponse(newOrder);
        }

        public async Task<OrderResponseDTO> GetOrderById(int id)
        {
            var getOrder = await _orderRepository.GetOrderById(id) ?? throw new Exception("Order Not found");
            return this.OrderToOrderResponse(getOrder);
        }

        public async Task<List<OrderResponseDTO>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            return orders.Select(o => new OrderResponseDTO
            {
                Id = o.Id,
                ProductId = o.ProductId,
                CustomerId = o.CustomerId,
                Quantity = o.Quantity,
                TotalPrice = o.TotalPrice,
                OrderDate = o.OrderDate,
                Status = o.Status
            }).ToList();
        }

        public async Task<string> DeleteOrder(int id)
        {
            var getOrder = await _orderRepository.GetOrderById(id) ?? throw new Exception("Order Not found");
            return await _orderRepository.DeleteOrder(getOrder);
        }

        public async Task<OrderResponseDTO> UpdateOrder(int id, OrderRequestDTO orderRequestDTO)
        {
            var getOrder = await _orderRepository.GetOrderById(id) ?? throw new Exception("Order Not found");
            getOrder.ProductId = orderRequestDTO.ProductId;
            getOrder.CustomerId = orderRequestDTO.CustomerId;
            getOrder.Quantity = orderRequestDTO.Quantity;
            getOrder.TotalPrice = 0;
            getOrder.Status = (Status)orderRequestDTO.Status;
            var updateOrder = await _orderRepository.UpdateOrder(getOrder);
            return this.OrderToOrderResponse(updateOrder);
        }

        private Order OrderRequestToOrder(OrderRequestDTO orderRequestDTO)
        {
            var order = new Order();
            order.ProductId = orderRequestDTO.ProductId;
            order.CustomerId = orderRequestDTO.CustomerId;
            order.Quantity = orderRequestDTO.Quantity;
            order.Status = (Status)orderRequestDTO.Status;
            return order;
        }
        private OrderResponseDTO OrderToOrderResponse(Order order)
        {
            var orderResponse = new OrderResponseDTO();
            orderResponse.Id = order.Id;
            orderResponse.ProductId = order.ProductId;
            orderResponse.CustomerId = order.CustomerId;
            orderResponse.Quantity = order.Quantity;
            orderResponse.TotalPrice = order.TotalPrice;
            orderResponse.OrderDate = order.OrderDate;
            orderResponse.Status = (Status)order.Status;
            return orderResponse;
        }
    }
}
