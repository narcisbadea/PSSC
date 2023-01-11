namespace E_Commerce.Domain.DTOs;

public class RegisterDTO
{
    public string  Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Address { get; set; } = String.Empty;
}
