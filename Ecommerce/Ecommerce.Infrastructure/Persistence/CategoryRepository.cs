using Ecommerce.Application.Persistence;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public CategoryRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category?> Create(Category category)
        {
            category.Id = Guid.NewGuid();
            category.CreatedDate = DateTime.Now;
            var response = await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Category?> Delete(Guid id)
        {
            var response = await _dbContext.Categories.FindAsync(id);
            if (response is not null)
            {
                response.IsDeleted = true;
                response.DeletedDate = DateTime.Now;
                await _dbContext.SaveChangesAsync();
                return response;
            }
            return null;
        }

        public async Task<List<Category>?> GetAll()
        {
            return await _dbContext.Categories.Where(d => !d.IsDeleted).Select(x => x).ToListAsync();
        }

        public async Task<Category?> GetById(Guid id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<Category?> Update(Guid id, Category category)
        {
            if (id.Equals(category.Id))
            {
                var response = await _dbContext.Categories.FindAsync(id);
                if (response is not null)
                {
                    response.Name = category.Name;
                    response.Image = category.Image;
                    response.Description = category.Description;
                    response.UpdatedDate = DateTime.Now;
                    await _dbContext.SaveChangesAsync();
                    return response;
                }
            }
            return null;
        }
    }
}
