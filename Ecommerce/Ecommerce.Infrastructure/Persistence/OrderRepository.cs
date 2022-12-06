using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public OrderRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order?> Create(Order order)
        {
            order.Id = Guid.NewGuid();
            var response = await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<List<Order>?> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order?> GetById(Guid id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }
    }
}
