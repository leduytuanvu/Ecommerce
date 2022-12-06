using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public ProductRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product?> Create(Product product)
        {
            product.Id = Guid.NewGuid();
            var response = await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Product?> Delete(Guid id)
        {
            var response = await _dbContext.Products.FindAsync(id);
            if (response is not null)
            {
                response.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                return response;
            }
            return null;
        }

        public async Task<List<Product>?> GetAll()
        {
            return await _dbContext.Products.Where(d => !d.IsDeleted).Select(x => x).ToListAsync();
        }

        public async Task<Product?> GetById(Guid id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<Product?> Update(Guid id, Product product)
        {
            if (id.Equals(product.Id))
            {
                var response = await _dbContext.Products.FindAsync(id);
                if (response is not null)
                {
                    response.Name = product.Name;
                    response.Description = product.Description;
                    response.Price = product.Price;
                    response.Quantity = product.Quantity;
                    await _dbContext.SaveChangesAsync();
                    return response;
                }
            }
            return null;
        }
    }
}
