using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Application.Services
{
    public class UrlCleanUpService : ICleanUpService<Url>
    {
        private readonly ApplicationDbContext _context;

        public UrlCleanUpService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CleanUp()
        {
            var expiredUrls = _context.Urls.Where(u => u.ExpirationDate <= DateTime.UtcNow).ToList();

            if(expiredUrls.Any())
            {
                _context.Urls.RemoveRange(expiredUrls);

                await _context.SaveChangesAsync();
            }
        }
    }
}
