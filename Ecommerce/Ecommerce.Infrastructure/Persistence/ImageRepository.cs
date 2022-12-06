using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence
{
    public class ImageRepository : IImageRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public ImageRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Image?> Create(Image image)
        {
            image.Id = Guid.NewGuid();
            var response = await _dbContext.Images.AddAsync(image);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Image?> Delete(Guid id)
        {
            var response = await _dbContext.Images.FindAsync(id);
            if (response is not null)
            {
                _dbContext.Remove(response);
                await _dbContext.SaveChangesAsync();
                return response;
            }
            return null;
        }

        public async Task<List<Image>?> GetAll()
        {
            return await _dbContext.Images.ToListAsync();
        }

        public async Task<Image?> GetById(Guid id)
        {
            return await _dbContext.Images.FindAsync(id);
        }

        public async Task<Image?> Update(Guid id, Image image)
        {
            if (id.Equals(image.Id))
            {
                var response = await _dbContext.Images.FindAsync(id);
                if (response is not null)
                {
                    response.Url = image.Url;
                    response.Alt = image.Alt;
                    response.Title = image.Title;
                    response.Description = image.Description;
                    await _dbContext.SaveChangesAsync();
                    return response;
                }
            }
            return null;
        }
    }
}
