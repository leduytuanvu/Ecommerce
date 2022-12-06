using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public OrderDetailRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderDetail?> Create(OrderDetail OrderDetail)
        {
            OrderDetail.Id = Guid.NewGuid();
            var response = await _dbContext.OrderDetails.AddAsync(OrderDetail);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<List<OrderDetail>?> GetAll()
        {
            return await _dbContext.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail?> GetById(Guid id)
        {
            return await _dbContext.OrderDetails.FindAsync(id);
        }
    }
}
