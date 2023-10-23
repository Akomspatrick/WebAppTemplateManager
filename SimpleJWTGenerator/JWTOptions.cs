namespace SimpleJWTGenerator
{
    public class JWTOptions
    {
        public string Issuer { get; set; } =string.Empty;
        public string Audience { get; set; } = string.Empty;
        public double ExpiresInMin { get; set; } = 0;
        public string SigningKey { get; set; } = string.Empty;
    }
}