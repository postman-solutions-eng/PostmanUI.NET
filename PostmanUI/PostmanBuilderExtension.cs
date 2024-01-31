using System.Net.Http.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.OpenApi.Models;

namespace PostmanUI
{
    public static class PostmanBuilderExtension
    {
        public static void UsePostmanBuilder(this WebApplication app, PostmanBuilderOptions options = null)
        {
            options ??= new();
            
            app.MapGet("/postman", async (HttpContext context, IHttpClientFactory client) => 
            {
                using var httpClient = client.CreateClient();

                var swaggerJson = await (await httpClient.GetAsync($"https://{context.Request.Host}{options?.SchemaPath}"))
                    .Content.ReadFromJsonAsync<OpenApiDocument>();
                
                return new RazorComponentResult<PostmanBuildView>(new 
                { 
                    Swagger = swaggerJson
                });
            });
        }
    }

    public class PostmanBuilderOptions 
    {
        public string SchemaPath { get; set; } = "/swagger/v1/swagger.json";
    }
}
