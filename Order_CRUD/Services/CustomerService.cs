using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Order_CRUD.DTOs.RequstDTOs;
using Order_CRUD.DTOs.ResponseDTOs;
using Order_CRUD.Entities;
using Order_CRUD.IRepositories;
using Order_CRUD.IServices;

namespace Order_CRUD.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _configuration;

        public CustomerService(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository;
            _configuration = configuration; 
        }
        public async Task<TokenModel>AddCustomer(CustomerRequestDTO customerRequestDTO)
        {
            var customer = this.CustomerRequestToCustomer(customerRequestDTO);
            customer.PasswordHash = BCrypt.Net.BCrypt.HashPassword(customerRequestDTO.PasswordHash);
            var newCustomer = await _customerRepository.AddCustomer(customer);
            return this.CreateToken(newCustomer);
        }

        public async Task<CustomerResponseDTO>GetCustomerById(int id)
        {
            var getCustomer = await _customerRepository.GetCustomerById(id)?? throw new Exception("Customer Not found"); 
           return this.CustomerToCustomerResponse(getCustomer);
        }

        public async Task<List<CustomerResponseDTO>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomers();
            return customers.Select(c => new CustomerResponseDTO
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                CreatedAt = c.CreatedAt
            }).ToList();       
        }

        public async Task<string>DeleteCustomer(int id)
        {
            var getCustomer = await _customerRepository.GetCustomerById(id) ?? throw new Exception("Customer Not found"); 
            return await _customerRepository.DeleteCustomer(getCustomer);   
        }

        public async Task<CustomerResponseDTO>UpdateCustomer(int id , CustomerRequestDTO customerRequestDTO)
        {
            var getCustomer = await _customerRepository.GetCustomerById(id) ?? throw new Exception("Customer Not found");
            getCustomer.Name = customerRequestDTO.Name;
            getCustomer.Email = customerRequestDTO.Email;
            getCustomer.Address = customerRequestDTO.Address;
            getCustomer.Phone = customerRequestDTO.Phone;
            var updateCustomer = await _customerRepository.UpdateCustomer(getCustomer);
            return this.CustomerToCustomerResponse(updateCustomer);
        }

        private Customer CustomerRequestToCustomer(CustomerRequestDTO customerRequestDTO) {
            var customer = new Customer();
            customer.Address = customerRequestDTO.Address;
            customer.Phone = customerRequestDTO.Phone;
            customer.Email = customerRequestDTO.Email;
            customer.Name = customerRequestDTO.Name;
            return customer;
        }
        private CustomerResponseDTO CustomerToCustomerResponse(Customer customer)
        {
            var customerResponse = new CustomerResponseDTO();
            customerResponse.Id = customer.Id;
            customerResponse.Name = customer.Name;
            customerResponse.Email = customer.Email;
            customerResponse.Phone = customer.Phone;
            customerResponse.Address = customer.Address;
            customerResponse.CreatedAt = customer.CreatedAt;
            return customerResponse;
        }
        private TokenModel CreateToken(Customer customer)
        {
            var claimList = new List<Claim>();
            claimList.Add(new Claim("Phone", customer.Phone));
            claimList.Add(new Claim("Email", customer.Email));
            claimList.Add(new Claim("Name", customer.Name));
            claimList.Add(new Claim("Address", customer.Address));

            var key = _configuration["JWT:Key"];
            var secKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claimList,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            var res = new TokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return res;
        }
    }
}
