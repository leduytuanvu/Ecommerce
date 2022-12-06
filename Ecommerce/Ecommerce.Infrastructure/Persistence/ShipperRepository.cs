using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public ShipperRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Shipper?> Create(Shipper shipper)
        {
            shipper.Id = Guid.NewGuid();
            var response = await _dbContext.Shippers.AddAsync(shipper);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Shipper?> Delete(Guid id)
        {
            var response = await _dbContext.Shippers.FindAsync(id);
            if (response is not null)
            {
                response.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                return response;
            }
            return null;
        }

        public async Task<List<Shipper>?> GetAll()
        {
            return await _dbContext.Shippers.Where(d => !d.IsDeleted).Select(x => x).ToListAsync();
        }

        public async Task<Shipper?> GetById(Guid id)
        {
            return await _dbContext.Shippers.FindAsync(id);
        }

        public async Task<Shipper?> Update(Guid id, Shipper shipper)
        {
            if (id.Equals(shipper.Id))
            {
                var response = await _dbContext.Shippers.FindAsync(id);
                if (response is not null)
                {
                    response.CompanyName = shipper.CompanyName;
                    response.Phone = shipper.Phone;
                    await _dbContext.SaveChangesAsync();
                    return response;
                }
            }
            return null;
        }
    }
}
