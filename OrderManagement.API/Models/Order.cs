public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending";

    public Customer Customer { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}