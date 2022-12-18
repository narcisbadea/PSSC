using E_Commerce.BLL.DTOs;
using E_Commerce.BLL.Services;
using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Comerce.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemResponseDTO>>> GetAllItemsAsync()
    {
        var result = await _itemService.GetAllItemsAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostItemAsync(ItemRequestDTO item)
    {
        await _itemService.InsertItemAsync(item);
        return Ok();
    }
}
