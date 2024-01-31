using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PostmanUI
{
    public static class PostmanUIExtensions
    {
        public static void UsePostmanBuilder(this WebApplication app)
        {
            app.MapGet("/postman", () => new RazorComponentResult<Index>());
        }
    }
}
