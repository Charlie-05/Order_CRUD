using Order_CRUD.Entities;

namespace Order_CRUD.IRepositories
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> GetCustomerById(int id);
        Task<List<Customer>> GetAllCustomers();
        Task<string> DeleteCustomer(Customer customer);
    }
}
