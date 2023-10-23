using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SimpleJWTGenerator
{
    public  class JWTProvider : IJWTProvider
    {
        private readonly JWTOptions _options;
        public JWTProvider(IOptions<JWTOptions> options)
        {
            _options= options.Value;
        }

        public string GenerateToken(string username, string password)
        {
            if (username != "admin" || password != "admin")
            {
                return "NO TOKEN GENERATED";
            }
            var claims = new[] { new System.Security.Claims.Claim("username", username) };  
            var credentials = new SigningCredentials(new SymmetricSecurityKey( Encoding.UTF8.GetBytes(_options.SigningKey)),
                SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                       issuer: _options.Issuer,//"http://localhost:5000",
                       audience: _options.Audience,//"http://localhost:5000",
                       claims: claims,
                       expires: DateTime.Now.AddMinutes(_options.ExpiresInMin),
                       signingCredentials : credentials);
                                                                                                         
           var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

           return tokenValue;
        }
    }
}
