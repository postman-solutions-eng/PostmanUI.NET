using Microsoft.AspNetCore.Components;
using Microsoft.OpenApi.Models;
using System.Text.Json;

namespace PostmanUI
{
    public partial class PostmanBuildView
    {
        [Parameter]
        public OpenApiDocument Swagger { get; set; }

        private string swaggerJson;
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        protected override void OnInitialized()
        {
            // serialize with system text json
            swaggerJson = JsonSerializer.Serialize(Swagger, jsonOptions);
        }
    }
}