namespace PostProject.Application.Features.Security.Password
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string passwordHash);
    }
}