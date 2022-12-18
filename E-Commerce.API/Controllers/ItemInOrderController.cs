using E_Commerce.BLL.DTOs;
using E_Commerce.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemInOrderController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public ItemInOrderController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost]
        public async Task<IActionResult> PostItemInOrder(ItemInOrderDTO itemInOrder)
        {
            await _orderItemService.AddItemInOrder(itemInOrder);
            return Ok();
        }
    }
}
