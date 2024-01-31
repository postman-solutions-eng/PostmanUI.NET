
namespace PostmanUIDemo
{
    public static class Endpoints
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapGet("/weatherforecast", () =>
            {
                return "Data";
            });

            app.MapGet("/test1", () =>
            {
            });
            
            app.MapGet("/test2", () =>
            {
            });

            app.MapGet("/test3", () =>
            {
            });

            app.MapGet("/test4", () =>
            {
            });
        }
    }
}
