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
        private string ErrorMessage;

        protected override async Task OnInitializedAsync()
        {
            using var httpClient = client.CreateClient();

            string path = $"https://{context.HttpContext.Request.Host}/swagger/v1/swagger.json";
            var getLocalSwaggerDocument = await httpClient.GetAsync(path);

            try
            {
                SwaggerJson = await (await httpClient.GetAsync(path))
                    .Content.ReadAsStringAsync();
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
        }
    }
}