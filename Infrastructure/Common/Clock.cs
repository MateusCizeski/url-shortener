using Infrastructure.Common.Interfaces;

namespace Infrastructure.Common
{
    public sealed class Clock : ISystemTime
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
