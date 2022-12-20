using E_Commerce.BLL.DTOs;
using E_Commerce.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemInOrderController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IAuthService _authService;

        public ItemInOrderController(IOrderItemService orderItemService, IAuthService authService)
        {
            _orderItemService = orderItemService;
            _authService = authService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostItemInOrder(ItemInOrderDTO itemInOrder)
        {
            var user = await _authService.GetLoggedUser();
            await _orderItemService.AddItemInOrder(itemInOrder, user);
            return Ok();
        }
    }
}
