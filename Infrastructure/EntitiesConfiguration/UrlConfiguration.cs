using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration
{
    internal sealed class UrlConfiguration : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OriginalUrl)
                .IsRequired();

            builder.Property(x => x.ShortenedUrl)
                .IsRequired();
        }
    }
}
