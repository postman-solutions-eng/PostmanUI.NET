using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using PostmanUI.Components;
using PostmanUI.Components.PostmanUtilities;

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
