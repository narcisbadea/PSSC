using E_Commerce.BLL.DTOs;
using E_Commerce.Domain.Models;
using System.IdentityModel.Tokens.Jwt;

namespace E_Commerce.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> CheckPassword(LoginDTO request);
        Task<JwtSecurityToken> GenerateToken(LoginDTO userLogin, bool rememberMe);
        Task<User> GetLoggedUser();
        Task<string> GetLoggedUserId();
        string GetLoggedUserName();
        Task<string> SignUp(RegisterDTO signup);
    }
}