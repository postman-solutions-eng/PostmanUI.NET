using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;

namespace PostmanUI
{
    public partial class Index
    {
        [Inject] private IHttpClientFactory client { get; set; }
        [Inject] private IHttpContextAccessor context { get; set; }

        private string SwaggerJson;
        private OpenApiDocument Swagger;
        private string ErrorMessage;

        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        // Initialize swaggerJson with the serialized swagger document
        protected override async Task OnInitializedAsync()
        {
            using var httpClient = client.CreateClient();

            string path = $"https://{context.HttpContext.Request.Host}/swagger/v1/swagger.json";
            var getLocalSwaggerDocument = await httpClient.GetAsync(path);

            try
            {
                Swagger = await (await httpClient.GetAsync(path))
                    .Content.ReadFromJsonAsync<OpenApiDocument>();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Unable to deserialize swagger document from path {path}";
                return;
            }

            if (getLocalSwaggerDocument.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ErrorMessage = $"Unable to get swagger document from path {path}";
                return;
            }

            var unsortedPaths = Swagger?.Paths;
            var sortedPaths = new OpenApiPaths();

            foreach (var openApiPath in unsortedPaths?.OrderBy(p => p.Key))
            {
                sortedPaths.Add(openApiPath.Key, openApiPath.Value);
            }

            Swagger.Paths = sortedPaths;
            SwaggerJson = JsonSerializer.Serialize(Swagger, jsonOptions);
        }
    }
}