﻿using E_Commerce.BLL.Services;
using E_Commerce.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IAuthService _authService;
        public OrderController(IOrderService orderService, IAuthService authService)
        {
            _orderService = orderService;
            _authService = authService;
        }

        [HttpPost("cancel")]
        [Authorize]
        public async Task<ActionResult<string>> CancelOrder(string orderId)
        {
            var user = await _authService.GetLoggedUser();
            return Ok(await _orderService.CancelOrder(orderId, user));
        }

        [HttpGet]
        public async Task<ActionResult<OrderDTO>> GetOrderToAdmin(string orderId)
        {
            return Ok(await _orderService.GetOrderByIdToAdmin(orderId));
        }

        [HttpPost("take")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> TakeOrder(string orderId)
        {
            return Ok(await _orderService.TakeOrder(orderId));
        }
    }
}
