namespace SimpleJWTGenerator
{
    public interface IJWTProvider
    {
        string GenerateToken(string username, string password);
    }
}
