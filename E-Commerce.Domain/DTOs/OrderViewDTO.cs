namespace E_Commerce.Domain.DTOs;

public class OrderViewDTO
{
    public string Id { get; set; }
    public string User { get; set; }
    public string Status { get; set; }
    public DateTime Created { get; set; }
}
