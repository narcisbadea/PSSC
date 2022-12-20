namespace E_Commerce.BLL.DTOs;

public class LoginDTO
{
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public bool rememberMe { get; set; } = false;
}
