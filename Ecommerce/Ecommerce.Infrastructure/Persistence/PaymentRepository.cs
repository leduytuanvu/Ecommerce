using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public PaymentRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Payment?> Create(Payment payment)
        {
            payment.Id = Guid.NewGuid();
            var response = await _dbContext.Payments.AddAsync(payment);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Payment?> Delete(Guid id)
        {
            var response = await _dbContext.Payments.FindAsync(id);
            if (response is not null)
            {
                response.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                return response;
            }
            return null;
        }

        public async Task<List<Payment>?> GetAll()
        {
            return await _dbContext.Payments.Where(d => !d.IsDeleted).Select(x => x).ToListAsync();
        }

        public async Task<Payment?> GetById(Guid id)
        {
            return await _dbContext.Payments.FindAsync(id);
        }

        public async Task<Payment?> Update(Guid id, Payment payment)
        {
            if (id.Equals(payment.Id))
            {
                var response = await _dbContext.Payments.FindAsync(id);
                if (response is not null)
                {
                    response.PaymentType = payment.PaymentType;
                    response.Expiry = payment.Expiry;
                    await _dbContext.SaveChangesAsync();
                    return response;
                }
            }
            return null;
        }
    }
}
