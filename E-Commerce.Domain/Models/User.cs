using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Domain.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
}
