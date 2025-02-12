using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_CRUD.DTOs.RequstDTOs;
using Order_CRUD.IServices;
using Order_CRUD.Services;

namespace Order_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderRequestDTO orderRequestDTO)
        {
            try
            {
                var data = await _orderService.AddOrder(orderRequestDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var data = await _orderService.GetOrderById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var data = await _orderService.GetAllOrders();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(int id, OrderRequestDTO orderRequestDTO)
        {
            try
            {
                var data = await _orderService.UpdateOrder(id, orderRequestDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var data = await _orderService.DeleteOrder(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
