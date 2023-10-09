using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class UserService : IUserService
{
    private readonly ApplicationDbContext context;

    public UserService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public Task<User> GetUser() => context.Users
        .Include(x => x.Orders)
        .OrderBy(x => x.Orders.Count)
        .LastAsync();

    public Task<List<User>> GetUsers() => context.Users
        .Where(x => x.Status == UserStatus.Inactive)
        .ToListAsync();
}
