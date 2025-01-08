namespace Domain.Entities
{
    public class Url : Entity
    {
        public string  ShortinedUrl { get; private set; }
        public string OriginalUrl { get; private set; }
        public DateTime ExpirationDate { get; private set; }
    }
}
