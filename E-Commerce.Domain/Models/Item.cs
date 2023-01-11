using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models;

public class Item
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ItemType Type { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Item() { }
    public Item(string id, string name, string description, ItemType type, decimal price, int quantity)
    {
        if (IsValidId(id) && IsValidName(name) && IsValidDescription(description) && IsValidType(type) && IsValidPrice(price) && IsValidQuantity(quantity))
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            Price = price;
            Quantity = quantity;
        }
        else
        {
            throw new InvalidItemInformationException($"Invalid information provided for item: id={id}, name={name}, description={description}, type={type}, price={price}, quantity={quantity}");
        }
    }

    private static bool IsValidId(string id) => !string.IsNullOrWhiteSpace(id);
    private static bool IsValidName(string name) => !string.IsNullOrWhiteSpace(name);
    private static bool IsValidDescription(string description) => !string.IsNullOrWhiteSpace(description);
    private static bool IsValidType(ItemType type) => Enum.IsDefined(typeof(ItemType), type);
    private static bool IsValidPrice(decimal price) => price > 0;
    private static bool IsValidQuantity(int quantity) => quantity > 0;

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Description: {Description}, Type: {Type}, Price: {Price}, Quantity: {Quantity}";
    }
}

public class InvalidItemInformationException : Exception
{
    public InvalidItemInformationException(string message) : base(message) { }
}