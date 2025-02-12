using Microsoft.EntityFrameworkCore;
using Order_CRUD.Database;
using Order_CRUD.Entities;
using Order_CRUD.IRepositories;

namespace Order_CRUD.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDBcontext _dbcontext;

        public CustomerRepository(AppDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var addedCustomer = await _dbcontext.Customers.AddAsync(customer);
            await _dbcontext.SaveChangesAsync();
            return addedCustomer.Entity;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _dbcontext.Customers.ToListAsync();
        }
        public async Task<Customer>GetCustomerById(int id)
        {
            return await _dbcontext.Customers.SingleOrDefaultAsync(customer => customer.Id == id);
        }

        public async Task<Customer>UpdateCustomer(Customer customer)
        {
            var updatedCustomer = _dbcontext.Customers.Update(customer);
             await _dbcontext.SaveChangesAsync();
            return updatedCustomer.Entity;
        }

        public async Task<string>DeleteCustomer(Customer customer)
        {
            var deleteCustomer = _dbcontext.Customers.Remove(customer);
            await _dbcontext.SaveChangesAsync();
            return "Successfully deleted";
        }
    }
}
