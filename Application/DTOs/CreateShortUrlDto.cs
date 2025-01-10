namespace Application.DTOs
{
    public record CreateShortUrlDto(string OriginalUrl, string? ShortenedUrl) { }
}
