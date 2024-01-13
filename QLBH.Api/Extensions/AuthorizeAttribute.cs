using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace QLBH.Api.Extensions
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _permissions;

        public AuthorizeAttribute(params string[] permissions)
        {
            _permissions = permissions;
        }

        public AuthorizeAttribute(string permission = "")
        {
            _permissions = new[] { permission };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var permissions = (List<Claim>)context.HttpContext.Items["permission"]!;
                if (!permissions.Any(permission => _permissions.Contains(permission.Value)))
                {
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                }
            }
            catch (Exception)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
