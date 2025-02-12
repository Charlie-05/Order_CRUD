using Order_CRUD.DTOs.RequstDTOs;
using Order_CRUD.DTOs.ResponseDTOs;

namespace Order_CRUD.IServices
{
    public interface ICustomerService
    {
        Task<TokenModel> AddCustomer(CustomerRequestDTO customerRequestDTO);
        Task<CustomerResponseDTO> GetCustomerById(int id);
        Task<List<CustomerResponseDTO>> GetAllCustomers();
        Task<string> DeleteCustomer(int id);
        Task<CustomerResponseDTO> UpdateCustomer(int id, CustomerRequestDTO customerRequestDTO);
    }
}
