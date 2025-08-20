using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace OrderManagement.API.Services;

public class OrderService : IOrderService
{
    
    private readonly AppDbContext _context;
    private readonly IMemoryCache _cache;

    public OrderService(AppDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }
    public async Task<IEnumerable<OrderDto>> GetRecentAsync(int days)
    {
        var orders = await _context.Orders
                        .Where(x => x.OrderDate >= CalculateRecentDateCutoff(days))
                        .OrderByDescending(o => o.OrderDate)
                        .ToListAsync();

        var orderDtos = orders.Select(order => new OrderDto(
            order.OrderId,
            order.CustomerId,
            order.OrderDate,
            order.TotalAmount,
            order.Status
        ));
        return orderDtos;
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        const string cacheKey = "GetAllOrders_cache";
        
        var cachedOrders = await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            entry.SetPriority(CacheItemPriority.Normal);
            
            var orders = await _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
                
            return orders.Select(order => new OrderDto(
                order.OrderId,
                order.CustomerId,
                order.OrderDate,
                order.TotalAmount,
                order.Status
            )).ToList();
        });
        
        return cachedOrders ?? Enumerable.Empty<OrderDto>();
    }

    public async Task<OrderDto> GetByIdAsync(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id)
                   ?? throw new InvalidOperationException($"Order with ID {id} not found.");

        return new OrderDto(
            order.OrderId,
            order.CustomerId,
            order.OrderDate,
            order.TotalAmount,
            order.Status
        );
    }

    public async Task<OrderDto> CreateAsync(CreateOrderDto createOrderDto)
    {
        var order = new Order
        {
            CustomerId = createOrderDto.CustomerId,
            OrderDate = createOrderDto.OrderDate,
            TotalAmount = createOrderDto.TotalAmount,
            Status = createOrderDto.Status
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return new OrderDto(
            order.OrderId,
            order.CustomerId,
            order.OrderDate,
            order.TotalAmount,
            order.Status
        );
    }

    private DateTime CalculateRecentDateCutoff(int days)
        => DateTime.UtcNow.AddDays(-days);
}