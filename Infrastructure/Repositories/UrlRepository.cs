using Domain.Entities;
using Domain.Errors;
using Domain.Interfaces;
using Infrastructure.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly DbSet<Url> _urls;
        private readonly IUnitOfWork _unitOfWork;

        public UrlRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _urls = context.Urls;
            _unitOfWork = unitOfWork;
        }

        public async Task<Url> AddShortUrl(Url url)
        {
            var createdUrl = await _urls.AddAsync(url);

            await _unitOfWork.SaveChanges();

            return createdUrl.Entity;
        }

        public async Task DeleteUrlById(Guid id)
        {
            Url? urlEntity = await _urls.FirstOrDefaultAsync(u => u.Id == id);
        
            if (urlEntity is null)
            {
                throw new ResourceNotFoundException($"Unable to DELETE URL with ID '{id}'");
            }

            _urls.Remove(urlEntity);

            await _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<Url>> GetAllShortUrls()
        {
            return await _urls.ToListAsync();
        }

        public async Task<Url?> GetUrlById(Guid id)
        {
            return await _urls.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Url> GetUrlByShortenedUrl(string path)
        {
            Url? urlEntity = await _urls.FirstOrDefaultAsync(u => u.ShortenedUrl == path);
        
            if (urlEntity is null)
            {
                throw new ResourceNotFoundException($"Unable to GET URL with Uri '{path}'.");
            }

            return urlEntity;
        }

        public async Task<bool> IsPathInUse(string path)
        {
            return await _urls.AnyAsync(u => u.ShortenedUrl.Equals(path));
        }
    }
}
