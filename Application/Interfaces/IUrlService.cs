using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUrlService
    {
        Task<IEnumerable<Url>> GetAllUrls();
        Task<string> GetUrlByShortenedUrl(string url);
        Task<Url?> GetUrlById(Guid id);
        Task DeleteUrl(Guid id);
        Task<Url> CreateShortUrl(CreateShortUrlDto dto);
    }
}
