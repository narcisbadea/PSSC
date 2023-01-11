using E_Commerce.Domain.Models;

public class Order
{
    public string Id { get; set; }
    public User User { get; set; }
    public Status Status { get; set; }
    public DateTime Created { get; set; }

    public Order() { }
    public Order(string id, User user, Status status, DateTime created)
    {
        if (IsValidId(id) && user != null && IsValidStatus(status) && created != null)
        {
            Id = id;
            User = user;
            Status = status;
            Created = created;
        }
        else
        {
            throw new InvalidOrderInformationException($"Invalid information provided for order: id={id}, user={user}, status={status}, created={created}");
        }
    }

    private static bool IsValidId(string id) => !string.IsNullOrWhiteSpace(id);
    private static bool IsValidStatus(Status status) => Enum.IsDefined(typeof(Status), status);

    public override string ToString()
    {
        return $"Id: {Id}, User: {User}, Status: {Status}, Created: {Created}";
    }
}

public class InvalidOrderInformationException : Exception
{
    public InvalidOrderInformationException(string message) : base(message) { }
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


