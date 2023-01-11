using Microsoft.AspNetCore.Identity;
namespace E_Commerce.Domain.Models;
public class User : IdentityUser
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Address { get; set; }

    public User() { }
    public User(string firstName, string lastName, string address)
    {
        if (IsValidName(firstName) && IsValidName(lastName) && IsValidAddress(address))
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
        else
        {
            throw new InvalidUserInformationException($"Invalid information provided for user: first name={firstName}, last name={lastName}, address={address}");
        }
    }

    private static bool IsValidName(string name) => !string.IsNullOrWhiteSpace(name);

    private static bool IsValidAddress(string address) => !string.IsNullOrWhiteSpace(address);

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Address: {Address}";
    }
}

public class InvalidUserInformationException : Exception
{
    public InvalidUserInformationException(string message) : base(message) { }
}
