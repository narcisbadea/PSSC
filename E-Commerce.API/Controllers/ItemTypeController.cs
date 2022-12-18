using E_Commerce.BLL.DTOs;
using E_Commerce.BLL.Services;
using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemTypeController : ControllerBase
    {
        private readonly IItemTypeService _itemTypeService;

        public ItemTypeController(IItemTypeService itemTypeService)
        {
            _itemTypeService = itemTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemType>>> GetAllItemTypesAsync()
        {
            var result = await _itemTypeService.GetAllItemTypesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostItemAsync(ItemTypeRequestDTO item)
        {
            await _itemTypeService.PostItemTypeAsync(item);
            return Ok();
        }
    }
}
