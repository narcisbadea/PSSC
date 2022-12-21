namespace E_Commerce.Domain.DTOs;

public class ItemRequestDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string TypeId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
