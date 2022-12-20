namespace E_Commerce.Domain.DTOs;

public class OrderDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public IEnumerable<ItemInOrderDTOToAdmin> Items { get; set; }
    public string Status { get; set; }
}
