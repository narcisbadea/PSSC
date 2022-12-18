namespace E_Commerce.Domain.Models;

public class OrderItem
{
    public string Id { get; set; }  
    public Order Order { get; set; }
    public Item Item { get; set; }
    public int Quantity { get; set; }
}
