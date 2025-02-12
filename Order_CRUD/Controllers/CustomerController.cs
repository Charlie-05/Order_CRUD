using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_CRUD.DTOs.RequstDTOs;
using Order_CRUD.IServices;

namespace Order_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                var data = await _customerService.AddCustomer(customerRequestDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> SignUp(CustomerRequestDTO customerRequestDTO)
        {
            
                var data = await _customerService.AddCustomer(customerRequestDTO);
                return Ok(data);
            
          
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetCustomerById(int id)
        {
            try
            {
                var data = await _customerService.GetCustomerById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var data = await _customerService.GetAllCustomers();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult>UpdateCustomer(int id , CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                var data = await _customerService.UpdateCustomer(id , customerRequestDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteCustomer(int id)
        {
            try
            {
                var data = await _customerService.DeleteCustomer(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
