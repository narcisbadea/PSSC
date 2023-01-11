namespace E_Commerce.Domain.DTOs;

public class ItemResponseDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
