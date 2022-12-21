namespace E_Commerce.Domain.DTOs;

public class LoginDTO
{
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public bool rememberMe { get; set; } = false;
}
