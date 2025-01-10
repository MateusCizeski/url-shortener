namespace Infrastructure.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}
