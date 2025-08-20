using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Filters;
using OrderManagement.API.Services;

namespace OrderManagement.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ILogger<OrdersController> _logger;
    public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }

    [HttpGet("recent")]
    [CacheResourceFilter(300)]
    public async Task<ActionResult> GetRecentOrders([FromQuery] int days = 7)
        => Ok(await _orderService.GetRecentAsync(days));

    [HttpGet]
    public async Task<ActionResult> GetAll()
        => Ok(await _orderService.GetAllAsync());
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
        => Ok(await _orderService.GetByIdAsync(id));

    [HttpPost]
    public async Task<ActionResult<Order>> Create(CreateOrderDto createOrderDto)
    {
        _logger.LogInformation("Creating Order...");
        var order = await _orderService.CreateAsync(createOrderDto);
        return CreatedAtAction(nameof(GetById), new { id = order.OrderId }, order);
    }
}

