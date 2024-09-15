using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace Poratl.ApiTask
{

    public class AuthOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            var isAuthorized = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                              context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            ///    if (!isAuthorized) return;

            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });

            var jwtbearerScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" }
            };

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [ jwtbearerScheme ] = new string [] { }
                }
            };

            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "lang",
                In = ParameterLocation.Header,
                Description = "Language",
                Required = false
            });

        }
    }
}
