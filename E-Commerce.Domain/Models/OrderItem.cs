namespace E_Commerce.Domain.Models;

public class OrderItem
{
    public string Id { get; set; }
    public Order Order { get; set; }
    public Item Item { get; set; }
    public int Quantity { get; set; }

    public OrderItem() { }
    public OrderItem(string id, Order order, Item item, int quantity)
    {
        if (IsValidId(id) && order != null && item != null && IsValidQuantity(quantity))
        {
            Id = id;
            Order = order;
            Item = item;
            Quantity = quantity;
        }
        else
        {
            throw new InvalidOrderItemInformationException($"Invalid information provided for order item: id={id}, order={order}, item={item}, quantity={quantity}");
        }
    }

    private static bool IsValidId(string id) => !string.IsNullOrWhiteSpace(id);
    private static bool IsValidQuantity(int quantity) => quantity > 0;

    public override string ToString()
    {
        return $"Id: {Id}, Order: {Order}, Item: {Item}, Quantity: {Quantity}";
    }
}

public class InvalidOrderItemInformationException : Exception
{
    public InvalidOrderItemInformationException(string message) : base(message) { }
}