namespace Order_CRUD.DTOs.RequstDTOs
{
    public class CustomerRequestDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PasswordHash { get; set; }
    }
}
