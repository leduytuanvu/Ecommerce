using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public SupplierRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Supplier?> Create(Supplier supplier)
        {
            supplier.Id = Guid.NewGuid();
            var response = await _dbContext.Suppliers.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Supplier?> Delete(Guid id)
        {
            var response = await _dbContext.Suppliers.FindAsync(id);
            if (response is not null)
            {
                response.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                return response;
            }
            return null;
        }

        public async Task<List<Supplier>?> GetAll()
        {
            return await _dbContext.Suppliers.Where(d => !d.IsDeleted).Select(x => x).ToListAsync();
        }

        public async Task<Supplier?> GetById(Guid id)
        {
            return await _dbContext.Suppliers.FindAsync(id);
        }

        public async Task<Supplier?> Update(Guid id, Supplier supplier)
        {
            if (id.Equals(supplier.Id))
            {
                var response = await _dbContext.Suppliers.FindAsync(id);
                if (response is not null)
                {
                    response.Name = supplier.Name;
                    response.Address1 = supplier.Address1;
                    response.Address2 = supplier.Address2;
                    response.Phone = supplier.Phone;
                    response.Email = supplier.Email;
                    response.Avatar = supplier.Avatar;
                    await _dbContext.SaveChangesAsync();
                    return response;
                }
            }
            return null;
        }
    }
}
