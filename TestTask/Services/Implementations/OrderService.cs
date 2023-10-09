using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext context;

    public OrderService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public Task<Order> GetOrder() => context.Orders
        .OrderBy(x => x.Price * x.Quantity)
        .LastAsync();

    public Task<List<Order>> GetOrders() => context.Orders
        .Where(x => x.Quantity > 10)
        .ToListAsync();
}
