namespace E_Commerce.Domain.Models;

public class Order
{
    public string Id { get; set; }
    public User User { get; set; }
    public Status Status { get; set; }
    public DateTime Created { get; set; }
}

public enum Status
{
    InProgress,
    Taken,
    OnHold,
    ReadyToBeDelivered,
    Shipped,
    cancelled,
    CanceledByTheCustomer
}
