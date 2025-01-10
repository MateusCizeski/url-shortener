namespace Application.Interfaces
{
    public interface ICleanUpService<T> where T : class
    {
        Task CleanUp();
    }
}
