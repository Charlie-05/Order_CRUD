namespace Order_CRUD.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public Status Status { get; set; } = Status.Pending;

    }

    public enum Status
    {
        Pending = 0,
        Completed = 1,
        Cancelled = 2,
    }
}
