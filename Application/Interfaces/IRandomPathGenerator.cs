namespace Application.Interfaces
{
    public interface IRandomPathGenerator
    {
        string GenerateRandomPath(int minLength, int maxLength);
    }
}
