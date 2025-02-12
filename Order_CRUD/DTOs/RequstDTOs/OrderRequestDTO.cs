using Order_CRUD.Entities;

namespace Order_CRUD.DTOs.RequstDTOs
{
    public class OrderRequestDTO
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public Status? Status { get; set; }
    }
}
