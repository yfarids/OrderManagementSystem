public interface IOrderService 
{
    Task<IEnumerable<OrderDto>> GetRecentAsync(int days);
    Task<IEnumerable<OrderDto>> GetAllAsync();
    Task<OrderDto> GetByIdAsync(int id);
    Task<OrderDto> CreateAsync(CreateOrderDto createOrderDto);
}