namespace E_Commerce.Domain.Models;

public class ItemType
{
    public string Id { get; set; }
    public string Name { get; set; }

    public ItemType() { }
    public ItemType(string id, string name)
    {
        if (IsValidId(id) && IsValidName(name))
        {
            Id = id;
            Name = name;
        }
        else
        {
            throw new InvalidItemTypeInformationException($"Invalid information provided for item type: id={id}, name={name}");
        }
    }

    private static bool IsValidId(string id) => !string.IsNullOrWhiteSpace(id);
    private static bool IsValidName(string name) => !string.IsNullOrWhiteSpace(name);

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}

public class InvalidItemTypeInformationException : Exception
{
    public InvalidItemTypeInformationException(string message) : base(message) { }
}
