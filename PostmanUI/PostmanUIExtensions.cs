using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PostmanUI
{
    public static class PostmanUIExtensions
    {
        public static void UsePostmanBuilder(this WebApplication app)
        {
            var group = app.MapGroup("/postman");

            group.MapGet("/", () => new RazorComponentResult<Index>()).ExcludeFromDescription();
            group.MapGet("/settings", () => new RazorComponentResult<Settings>()).ExcludeFromDescription();
        }
    }
}
