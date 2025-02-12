using Order_CRUD.Entities;

namespace Order_CRUD.DTOs.ResponseDTOs
{
    public class OrderResponseDTO
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public Status Status { get; set; }
    }
}
