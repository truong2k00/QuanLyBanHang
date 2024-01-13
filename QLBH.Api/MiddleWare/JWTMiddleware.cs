using Microsoft.IdentityModel.Tokens;
using QLBH.Commons;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QLBH.Api.MiddleWare
{
    public class JWTMiddleware : IMiddleware
    {
        private readonly IConfiguration _configuration;

        public JWTMiddleware(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string Token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(Token))
            {
                Token = Convert.ToString(context.Request.Query["access_token"]);
            }
            if (Token != null)
            {
                AttachUserToContext(context, Token);
            }
            return next(context);
        }
        public void AttachUserToContext(HttpContext context, string Token)
        {
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_configuration.GetSection(Common_Constants.AppSettingKeys.AUTH_SECRET).Value!);
            TokenHandler.ValidateToken(Token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;

            var permissions = jwtToken.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
            context.Items[Common_Constants.ContextItem.PERMISSIONS] = permissions;
        }
    }
}
